namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts/{id}

public static class DeleteReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts/1";

        var response = await client.DeleteAsync(url);

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Expected 200 OK but got {response.StatusCode}");
        }
    }
}
