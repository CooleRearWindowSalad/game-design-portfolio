namespace SharedFridge.Models;

/// <summary>
/// A housemate, loaded from wwwroot/data/housemates.json. Their morning note depends on whether they
/// noticed a theft and how suspicious they are now: <see cref="NoticedNotes"/> is indexed by
/// suspicion 1–3 (the last one is the confrontation), <see cref="QuietNotes"/> by suspicion 0–2.
/// Noticed notes can use {item}, {price} and {count}.
/// </summary>
public sealed record Housemate(
    int Id,
    string Name,
    DetectionRule Rule,
    IReadOnlyList<string> NoticedNotes,
    IReadOnlyList<string> QuietNotes);
