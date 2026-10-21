using System.Net.Http.Json;
using SharedFridge.Models;

namespace SharedFridge.Data;

/// <summary>Loads the game's content from the JSON files in wwwroot/data.</summary>
public sealed class GameDataLoader(HttpClient http)
{
    public Task<IReadOnlyList<Housemate>> LoadHousematesAsync() => LoadListAsync<Housemate>("data/housemates.json");

    public Task<IReadOnlyList<RecipeTier>> LoadRecipeTiersAsync() => LoadListAsync<RecipeTier>("data/recipe-tiers.json");

    private async Task<IReadOnlyList<T>> LoadListAsync<T>(string path) =>
        await http.GetFromJsonAsync<List<T>>(path) ?? [];
}
