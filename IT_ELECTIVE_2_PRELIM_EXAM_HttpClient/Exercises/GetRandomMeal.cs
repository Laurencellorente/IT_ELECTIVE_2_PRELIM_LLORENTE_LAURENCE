namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class GetRandomMeal
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/random.php";


        var response = await client.GetAsync(url);


        string body = await response.Content.ReadAsStringAsync();


        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Status code is not 200 OK.");

        if (string.IsNullOrWhiteSpace(body))
            throw new Exception("Response body is empty.");
    }
}