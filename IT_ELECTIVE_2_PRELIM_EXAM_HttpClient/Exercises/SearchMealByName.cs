using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class SearchMealByName
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/search.php?s=Arrabiata";

        
        var response = await client.GetAsync(url);

        
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Status code is not 200 OK.");

      
        string body = await response.Content.ReadAsStringAsync();

       
        using JsonDocument document = JsonDocument.Parse(body);

        if (!document.RootElement.TryGetProperty("meals", out JsonElement meals))
            throw new Exception("Response does not contain 'meals'.");

        if (meals.ValueKind == JsonValueKind.Null)
            throw new Exception("'meals' is null.");

        if (meals.GetArrayLength() < 1)
            throw new Exception("No meals found.");
    }
}