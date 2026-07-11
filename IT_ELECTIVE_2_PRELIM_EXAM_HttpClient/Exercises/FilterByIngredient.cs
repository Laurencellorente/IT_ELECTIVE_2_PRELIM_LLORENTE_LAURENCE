using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class FilterByIngredient
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/filter.php?i=chicken_breast";

        // Send GET request
        var response = await client.GetAsync(url);

        // Check status code
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Status code is not 200 OK.");

        // Read response body
        string body = await response.Content.ReadAsStringAsync();

        // Parse JSON
        using JsonDocument document = JsonDocument.Parse(body);

        JsonElement meals = document.RootElement.GetProperty("meals");

        // Check if meals exists
        if (meals.ValueKind == JsonValueKind.Null)
            throw new Exception("Meals array is null.");

        // Check that at least one meal exists
        if (meals.GetArrayLength() < 1)
            throw new Exception("No meals found for the ingredient.");
    }
}