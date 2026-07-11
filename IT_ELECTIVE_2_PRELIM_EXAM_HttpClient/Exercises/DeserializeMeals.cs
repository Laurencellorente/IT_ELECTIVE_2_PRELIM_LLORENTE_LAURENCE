namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

using System.Net;
using System.Text.Json;

public static class DeserializeMeals
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/search.php?f=a";

        
        var response = await client.GetAsync(url);

        
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Expected 200 OK but got {response.StatusCode}");
        }

        string json = await response.Content.ReadAsStringAsync();

       
        using JsonDocument doc = JsonDocument.Parse(json);

        var meals = doc.RootElement.GetProperty("meals");

        if (meals.GetArrayLength() <= 0)
        {
            throw new Exception("No meals found.");
        }

       
        foreach (var meal in meals.EnumerateArray())
        {
            string mealName = meal.GetProperty("strMeal").GetString() ?? "Unknown";

            Console.WriteLine($"      Meal: {mealName}");
        }
    }
}