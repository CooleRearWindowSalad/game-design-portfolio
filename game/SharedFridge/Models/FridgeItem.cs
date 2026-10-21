namespace SharedFridge.Models;

/// <summary>
/// One item on a fridge shelf, loaded from wwwroot/data/fridge.json.
/// <see cref="OwnerId"/> 0 is the player's own shelf.
/// </summary>
public sealed record FridgeItem(int Id, int OwnerId, string Name, string Icon, decimal Price, bool IsFavourite = false);
