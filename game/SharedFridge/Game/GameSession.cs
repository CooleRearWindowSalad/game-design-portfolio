using SharedFridge.Models;

namespace SharedFridge.Game;

/// <summary>Which screen the game is on.</summary>
public enum GamePhase
{
    Title,
    Intro,
    Night,
}

/// <summary>
/// The state of one playthrough. Components read from it and subscribe to
/// <see cref="Changed"/> to re-render when it updates.
/// </summary>
public sealed class GameSession
{
    public const int TotalNights = 7;
    public const decimal StartingBudget = 10m;

    private readonly Dictionary<int, int> suspicion = [];
    private readonly HashSet<int> takenTonight = [];

    public event Action? Changed;

    public GamePhase Phase { get; private set; } = GamePhase.Title;
    public int Night { get; private set; }
    public decimal Budget { get; private set; }
    public int Score { get; private set; }

    public int SuspicionOf(Housemate housemate) => suspicion.GetValueOrDefault(housemate.Id);

    public bool IsTaken(FridgeItem item) => takenTonight.Contains(item.Id);

    /// <summary>Takes an item off its shelf, or puts it back if it was already taken.</summary>
    public void ToggleTaken(FridgeItem item)
    {
        if (!takenTonight.Remove(item.Id))
        {
            takenTonight.Add(item.Id);
        }

        Changed?.Invoke();
    }

    public void Start()
    {
        Phase = GamePhase.Intro;
        Night = 0;
        Budget = StartingBudget;
        Score = 0;
        suspicion.Clear();
        takenTonight.Clear();
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
