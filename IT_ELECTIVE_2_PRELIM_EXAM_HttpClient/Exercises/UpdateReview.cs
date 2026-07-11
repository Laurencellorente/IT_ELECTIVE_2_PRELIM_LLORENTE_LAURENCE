using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class UpdateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts/1";

        
        string json = @"{
            ""id"": 1,
            ""title"": ""Updated Review"",
            ""body"": ""Even better than before!"",
            ""userId"": 1
        }";

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        
        var response = await client.PutAsync(url, content);

        
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Status code is not 200 OK.");

        string body = await response.Content.ReadAsStringAsync();

       
        using JsonDocument document = JsonDocument.Parse(body);

       
        string? title = document.RootElement.GetProperty("title").GetString();

        if (title != "Updated Review")
            throw new Exception($"Expected 'Updated Review' but got '{title}'.");
    }
}
