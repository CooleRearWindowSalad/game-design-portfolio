namespace SharedFridge.Models;

/// <summary>One page of the opening story, loaded from wwwroot/data/intro.json.</summary>
public sealed record IntroPart(string Eyebrow, string Title, IReadOnlyList<string> Paragraphs);
