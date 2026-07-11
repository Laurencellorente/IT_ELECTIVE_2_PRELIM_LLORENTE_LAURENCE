using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class GetMealById
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/lookup.php?i=52772";

        // Send GET request
        var response = await client.GetAsync(url);

        // Check status code
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Status code is not 200 OK.");

        // Read response
        string body = await response.Content.ReadAsStringAsync();

        // Parse JSON
        using JsonDocument document = JsonDocument.Parse(body);

        JsonElement meals = document.RootElement.GetProperty("meals");

        if (meals.ValueKind == JsonValueKind.Null || meals.GetArrayLength() == 0)
            throw new Exception("Meal not found.");

        string mealName = meals[0].GetProperty("strMeal").GetString()!;

        if (mealName != "Arrabiata")
            throw new Exception($"Expected 'Arrabiata' but got '{mealName}'.");
    }
}