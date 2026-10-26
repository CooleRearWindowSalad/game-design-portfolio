namespace SharedFridge.Kitchen;

public static class IngredientText
{
    /// <summary>Lists ingredient names for a sentence: "Egg ×2, Garlic and Pesto".</summary>
    public static string Describe(IEnumerable<string> names)
    {
        var parts = names.GroupBy(n => n).Select(g => g.Count() > 1 ? $"{g.Key} ×{g.Count()}" : g.Key).ToList();

        return parts.Count <= 1
            ? string.Concat(parts)
            : $"{string.Join(", ", parts[..^1])} and {parts[^1]}";
    }
}
