namespace SharedFridge.Models;

/// <summary>Harder recipes score more but need more stolen ingredients.</summary>
public sealed record RecipeTier(string Name, int Points);
