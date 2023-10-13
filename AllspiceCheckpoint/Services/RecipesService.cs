




namespace AllspiceCheckpoint.Services;

public class RecipesService
{
    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
        _repo = repo;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe newRecipe = _repo.CreateRecipe(recipeData);
        return newRecipe;
    }

    internal List<Recipe> GetAllRecipes()
    {
        List<Recipe> recipes = _repo.GetAllRecipes();
        return recipes;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _repo.GetRecipeById(recipeId);
        return recipe;
    }

    internal void DeleteRecipe(int recipeId, string userId)
    {
        // FIXME: have the following error: Code other than 400 returned, make sure you are throwing a bad request when trying to get data that doesn't exist!: expected 204 to be one of [ 400 ]
        Recipe foundRecipe = _repo.GetRecipeById(recipeId);
        if (foundRecipe == null) throw new Exception("Invalid recipe id");
        if (foundRecipe.CreatorId != userId) throw new Exception("Unauthorized to remove");
        int rows = _repo.DeleteRecipe(recipeId);
        if (rows > 1) throw new Exception("Something bad has happened");
        if (rows < 1) throw new Exception("Something REALLY bad has happened");
    }

}


