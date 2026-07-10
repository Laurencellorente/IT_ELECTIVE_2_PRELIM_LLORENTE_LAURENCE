namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 3: GET Lookup by ID
// TheMealDB API: https://themealdb.com/api/json/v1/1/lookup.php?i={id}
//
// Your task:
// 1. Use the HttpClient to look up meal with ID 52772
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the meal name is "Arrabiata"
//
// Note: TheMealDB meal IDs are numeric (52771 = Arrabiata)

public static class GetMealById
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Send GET request to https://themealdb.com/api/json/v1/1/lookup.php?i=52771
        // TODO: Assert status code is 200 OK
        // TODO: Parse the response JSON
        // TODO: Assert the meal name (strMeal) is "Arrabiata"

        throw new NotImplementedException();
    }
}
