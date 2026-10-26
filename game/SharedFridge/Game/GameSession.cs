using System.Globalization;
using SharedFridge.Models;

namespace SharedFridge.Game;

/// <summary>Which screen the game is on.</summary>
public enum GamePhase
{
    Title,
    Intro,
    Night,
    Morning,
    End,
}

/// <summary>A dish the player cooked, and the points it scored.</summary>
public sealed record CookedMeal(int Night, Recipe Recipe, int Points);

/// <summary>A note a housemate left on the fridge in the morning.</summary>
public sealed record MorningNote(Housemate Housemate, string Text);

/// <summary>
/// The state of one playthrough. Components read from it and subscribe to
/// <see cref="Changed"/> to re-render when it updates.
/// </summary>
public sealed class GameSession
{
    public const int TotalNights = 7;
    public const decimal StartingBudget = 10m;
    public const int DishesPerTier = 2;

    /// <summary>A housemate this suspicious confronts the player, and the game is over.</summary>
    public const int MaxSuspicion = 3;

    private readonly Dictionary<int, int> suspicion = [];
    private readonly HashSet<int> takenTonight = [];
    private readonly HashSet<int> eatenTonight = [];
    private readonly List<CookedMeal> meals = [];
    private readonly List<MorningNote> notes = [];
    private int menuSeed;

    public event Action? Changed;

    public GamePhase Phase { get; private set; } = GamePhase.Title;
    public int Night { get; private set; }
    public decimal Budget { get; private set; }
    public int Score { get; private set; }

    public IReadOnlyList<CookedMeal> Meals => meals;

    /// <summary>One meal a night: null until the player has cooked tonight.</summary>
    public CookedMeal? CookedTonight => meals.LastOrDefault(m => m.Night == Night);

    /// <summary>The notes from the most recent morning. They stay on the fridge through the next night.</summary>
    public IReadOnlyList<MorningNote> Notes => notes;

    /// <summary>The housemate who confronted the player, if the game ended that way.</summary>
    public Housemate? CaughtBy { get; private set; }

    public bool WentHungryLastNight => Night > 1 && meals.All(m => m.Night != Night - 1);

    public bool HasCounterItems => takenTonight.Count > 0;

    /// <summary>
    /// Bed only once the counter is cleared (leftovers would give you away), and nobody skips
    /// dinner two nights in a row, so the player can't sleep through the week to stay safe.
    /// </summary>
    public bool CanSleep => !HasCounterItems && (CookedTonight is not null || !WentHungryLastNight);

    public int SuspicionOf(Housemate housemate) => suspicion.GetValueOrDefault(housemate.Id);

    public bool IsTaken(FridgeItem item) => takenTonight.Contains(item.Id);

    public bool IsEaten(FridgeItem item) => eatenTonight.Contains(item.Id);

    /// <summary>Takes an item off its shelf, or puts it back if it was already taken.</summary>
    public void ToggleTaken(FridgeItem item)
    {
        if (IsEaten(item))
        {
            return;
        }

        if (!takenTonight.Remove(item.Id))
        {
            takenTonight.Add(item.Id);
        }

        Changed?.Invoke();
    }

    public void PutAllBack()
    {
        takenTonight.Clear();
        Changed?.Invoke();
    }

    /// <summary>
    /// Tonight's dishes: <see cref="DishesPerTier"/> from each tier. Each tier is shuffled once per
    /// playthrough and dealt out in turn, so the menu changes every night and a dish only comes back
    /// once the rest of its tier has been on the board.
    /// </summary>
    public IReadOnlyList<Recipe> MenuTonight(IReadOnlyList<RecipeTier> tiers, IReadOnlyList<Recipe> recipes)
    {
        var menu = new List<Recipe>();

        for (var t = 0; t < tiers.Count; t++)
        {
            var pool = recipes.Where(r => r.Tier == tiers[t].Name).ToArray();
            new Random(menuSeed + t).Shuffle(pool);

            for (var i = 0; i < Math.Min(DishesPerTier, pool.Length); i++)
            {
                menu.Add(pool[((Night - 1) * DishesPerTier + i) % pool.Length]);
            }
        }

        return menu;
    }

    /// <summary>
    /// Matches a recipe against the items on the counter, using the player's own food before
    /// anyone else's. <c>Missing</c> lists the ingredient names still to fetch.
    /// </summary>
    public (IReadOnlyList<FridgeItem> Found, IReadOnlyList<string> Missing) CheckCounter(Recipe recipe, IEnumerable<FridgeItem> items)
    {
        var counter = items.Where(IsTaken).OrderBy(i => i.OwnerId != 0).ToList();
        var found = new List<FridgeItem>();
        var missing = new List<string>();

        foreach (var name in recipe.Ingredients)
        {
            var match = counter.FirstOrDefault(i => i.Name == name);
            if (match is null)
            {
                missing.Add(name);
            }
            else
            {
                counter.Remove(match);
                found.Add(match);
            }
        }

        return (found, missing);
    }

    /// <summary>Cooks a dish from the counter, if every ingredient is there and nothing's been cooked tonight.</summary>
    public void Cook(Recipe recipe, int points, IEnumerable<FridgeItem> items)
    {
        var (found, missing) = CheckCounter(recipe, items);
        if (CookedTonight is not null || missing.Count > 0)
        {
            return;
        }

        foreach (var item in found)
        {
            takenTonight.Remove(item.Id);
            eatenTonight.Add(item.Id);
        }

        meals.Add(new CookedMeal(Night, recipe, points));
        Score += points;
        Changed?.Invoke();
    }

    /// <summary>
    /// Ends the night and moves on to the morning. Each housemate checks their shelf in their own
    /// way: a noticed theft raises their suspicion, a night with nothing taken from them lowers it,
    /// and anything taken but unnoticed leaves it as it was. Their note says how they feel.
    /// The housemates restock their shelves before the next night.
    /// </summary>
    public void Sleep(IReadOnlyList<FridgeItem> items, IReadOnlyList<Housemate> housemates)
    {
        if (Phase != GamePhase.Night || !CanSleep)
        {
            return;
        }

        notes.Clear();

        foreach (var housemate in housemates)
        {
            var eaten = items.Where(i => i.OwnerId == housemate.Id && IsEaten(i)).ToList();
            var noticed = Detection.Notices(housemate.Rule, eaten);
            var level = SuspicionOf(housemate);

            if (noticed.Count > 0)
            {
                level = Math.Min(level + 1, MaxSuspicion);
            }
            else if (eaten.Count == 0)
            {
                level = Math.Max(level - 1, 0);
            }

            suspicion[housemate.Id] = level;

            var text = noticed.Count > 0
                ? Fill(Pick(housemate.NoticedNotes, level - 1), noticed)
                : Pick(housemate.QuietNotes, level);
            notes.Add(new MorningNote(housemate, text));

            if (level >= MaxSuspicion)
            {
                CaughtBy ??= housemate;
            }
        }

        takenTonight.Clear();
        eatenTonight.Clear();
        Phase = GamePhase.Morning;
        Changed?.Invoke();
    }

    /// <summary>After reading the notes: the next night, or the end if someone confronted you or it's payday.</summary>
    public void FinishMorning()
    {
        if (Phase != GamePhase.Morning)
        {
            return;
        }

        if (CaughtBy is not null || Night >= TotalNights)
        {
            Phase = GamePhase.End;
        }
        else
        {
            Night++;
            Phase = GamePhase.Night;
        }

        Changed?.Invoke();
    }

    private static string Pick(IReadOnlyList<string> notes, int index) =>
        notes.Count == 0 ? "" : notes[Math.Clamp(index, 0, notes.Count - 1)];

    // The note names the priciest thing that was noticed
    private static string Fill(string template, IReadOnlyList<FridgeItem> noticed)
    {
        var priciest = noticed.MaxBy(i => i.Price)!;

        return template
            .Replace("{item}", priciest.Name.ToLowerInvariant())
            .Replace("{price}", priciest.Price.ToString("0.00", CultureInfo.InvariantCulture))
            .Replace("{count}", noticed.Count.ToString(CultureInfo.InvariantCulture));
    }

    public void Start()
    {
        Phase = GamePhase.Intro;
        Night = 0;
        Budget = StartingBudget;
        Score = 0;
        menuSeed = Random.Shared.Next();
        CaughtBy = null;
        suspicion.Clear();
        takenTonight.Clear();
        eatenTonight.Clear();
        meals.Clear();
        notes.Clear();
        Changed?.Invoke();
    }

    public void FinishIntro()
    {
        Phase = GamePhase.Night;
        Night = 1;
        Changed?.Invoke();
    }

    public void Quit()
    {
        Phase = GamePhase.Title;
        Night = 0;
        Changed?.Invoke();
    }
}
