using System.Text.Json.Serialization;

namespace SharedFridge.Models;

/// <summary>How a housemate notices missing food. Never shown to the player directly.</summary>
[JsonConverter(typeof(JsonStringEnumConverter<DetectionRule>))]
public enum DetectionRule
{
    CountsItems,
    ChecksQuality,
    SecretFavourite,
}
