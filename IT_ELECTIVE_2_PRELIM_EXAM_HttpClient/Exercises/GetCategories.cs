using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class GetCategories
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/categories.php";

        // Send GET request
        var response = await client.GetAsync(url);

        // Check status code
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Status code is not 200 OK.");


        string body = await response.Content.ReadAsStringAsync();


        using JsonDocument document = JsonDocument.Parse(body);

        JsonElement categories = document.RootElement.GetProperty("categories");


        if (categories.ValueKind == JsonValueKind.Null)
            throw new Exception("Categories array is null.");


        if (categories.GetArrayLength() == 0)
            throw new Exception("No categories found.");
    }
}