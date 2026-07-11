namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

using System.Net;
using System.Text.Json;

public static class HandleNotFound
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/lookup.php?i=999999";

        // Send GET request
        var response = await client.GetAsync(url);

        // Assert status code is 200 OK
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Expected 200 OK but got {response.StatusCode}");
        }

        // Read JSON response
        string json = await response.Content.ReadAsStringAsync();

        // Parse JSON
        using JsonDocument doc = JsonDocument.Parse(json);

        // Get "meals" field
        var meals = doc.RootElement.GetProperty("meals");

        // Assert meals is null
        if (meals.ValueKind != JsonValueKind.Null)
        {
            throw new Exception("Expected meals to be null, but a meal was found.");
        }
    }
}