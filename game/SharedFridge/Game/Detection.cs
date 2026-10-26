using SharedFridge.Models;

namespace SharedFridge.Game;

/// <summary>What each kind of housemate notices when their food goes missing.</summary>
public static class Detection
{
    /// <summary>A housemate who checks quality only misses things at least this expensive.</summary>
    public const decimal ExpensiveFrom = 2.00m;

    /// <summary>The items, out of those eaten from a housemate's shelf, that they notice are gone.</summary>
    public static IReadOnlyList<FridgeItem> Notices(DetectionRule rule, IEnumerable<FridgeItem> eaten) => rule switch
    {
        DetectionRule.CountsItems => eaten.ToList(),
        DetectionRule.ChecksQuality => eaten.Where(i => i.Price >= ExpensiveFrom).ToList(),
        DetectionRule.SecretFavourite => eaten.Where(i => i.IsFavourite).ToList(),
        _ => [],
    };
}
