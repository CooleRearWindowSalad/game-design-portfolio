namespace SharedFridge.Models;

/// <summary>
/// A dish the player can cook, loaded from wwwroot/data/recipes.json.
/// <see cref="Tier"/> names a <see cref="RecipeTier"/>. Each ingredient is a fridge item name,
/// listed once per item needed (two eggs is "Egg", "Egg").
/// </summary>
public sealed record Recipe(string Name, string Icon, string Tier, IReadOnlyList<string> Ingredients);
