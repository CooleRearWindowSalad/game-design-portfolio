using System.Net.Http.Json;
using SharedFridge.Models;

namespace SharedFridge.Data;

/// <summary>Loads the game's content from the JSON files in wwwroot/data.</summary>
public sealed class GameDataLoader(HttpClient http)
{
    public Task<IReadOnlyList<Housemate>> LoadHousematesAsync() => LoadListAsync<Housemate>("data/housemates.json");

    public Task<IReadOnlyList<RecipeTier>> LoadRecipeTiersAsync() => LoadListAsync<RecipeTier>("data/recipe-tiers.json");

    public Task<IReadOnlyList<Recipe>> LoadRecipesAsync() => LoadListAsync<Recipe>("data/recipes.json");

    public Task<IReadOnlyList<IntroPart>> LoadIntroAsync() => LoadListAsync<IntroPart>("data/intro.json");

    public Task<IReadOnlyList<FridgeItem>> LoadFridgeAsync() => LoadListAsync<FridgeItem>("data/fridge.json");

    private async Task<IReadOnlyList<T>> LoadListAsync<T>(string path) =>
        await http.GetFromJsonAsync<List<T>>(path) ?? [];
}
