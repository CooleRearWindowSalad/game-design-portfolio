namespace SharedFridge.Models;

/// <summary>A housemate, loaded from wwwroot/data/housemates.json.</summary>
public sealed record Housemate(int Id, string Name, DetectionRule Rule);
