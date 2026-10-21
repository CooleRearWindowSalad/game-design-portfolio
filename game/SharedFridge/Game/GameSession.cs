using SharedFridge.Models;

namespace SharedFridge.Game;

/// <summary>
/// The state of one playthrough. Components read from it and subscribe to
/// <see cref="Changed"/> to re-render when it updates.
/// </summary>
public sealed class GameSession
{
    public const int TotalNights = 7;
    public const decimal StartingBudget = 10m; 

    private readonly Dictionary<int, int> suspicion = []; 

    public event Action? Changed;

    public bool IsRunning { get; private set; }
    public int Night { get; private set; }
    public decimal Budget { get; private set; }
    public int Score { get; private set; }

    public int SuspicionOf(Housemate housemate) => suspicion.GetValueOrDefault(housemate.Id);

    public void Start()
    {
        IsRunning = true;
        Night = 1;
        Budget = StartingBudget;
        Score = 0;
        suspicion.Clear();
        Changed?.Invoke();
    }

    public void Quit()
    {
        IsRunning = false;
        Night = 0;
        Changed?.Invoke();
    }
}
