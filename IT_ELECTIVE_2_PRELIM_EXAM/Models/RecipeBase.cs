namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

public class RecipeBase
{
    public string Title { get; set; }
    public int PrepTimeMinutes { get; set; }
    public string Difficulty { get; set; }

    protected List<string> steps;

    public RecipeBase()
    {
        Title = "";
        PrepTimeMinutes = 0;
        Difficulty = "Easy";
        steps = new List<string>();
    }

    public RecipeBase(string title, int prepTime, string difficulty)
    {
        Title = title;
        PrepTimeMinutes = prepTime;
        Difficulty = difficulty;
        steps = new List<string>();
    }

    public virtual string GetRecipeInfo()
    {
        return $"Recipe: {Title} | Prep: {PrepTimeMinutes} min | Difficulty: {Difficulty}";
    }

    public virtual void AddStep(string step)
    {
        steps.Add(step);
    }

    public List<string> GetSteps()
    {
        return new List<string>(steps);
    }
}