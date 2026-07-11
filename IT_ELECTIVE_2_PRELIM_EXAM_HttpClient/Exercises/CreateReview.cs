using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class CreateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts";


        string json = @"{
            ""title"": ""Great Pasta!"",
            ""body"": ""Loved this recipe"",
            ""userId"": 1
        }";

        var content = new StringContent(json, Encoding.UTF8, "application/json");


        var response = await client.PostAsync(url, content);


        if (response.StatusCode != System.Net.HttpStatusCode.Created)
            throw new Exception("Status code is not 201 Created.");

        string body = await response.Content.ReadAsStringAsync();


        using JsonDocument document = JsonDocument.Parse(body);


        if (!document.RootElement.TryGetProperty("id", out JsonElement id))
            throw new Exception("Response does not contain an id.");

        if (id.GetInt32() <= 0)
            throw new Exception("Invalid id returned.");
    }
}