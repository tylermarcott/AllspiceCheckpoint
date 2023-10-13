




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
        Recipe foundRecipe = _repo.GetRecipeById(recipeId);
        if (foundRecipe == null) throw new Exception("Invalid recipe id");
        return foundRecipe;
    }

    internal void DeleteRecipe(int recipeId, string userId)
    {
        Recipe foundRecipe = _repo.GetRecipeById(recipeId);
        if (foundRecipe.CreatorId != userId) throw new Exception("Unauthorized to remove");
        int rows = _repo.DeleteRecipe(recipeId);
        if (rows > 1) throw new Exception("Something bad has happened");
        if (rows < 1) throw new Exception("Something REALLY bad has happened");
    }

    internal Recipe EditRecipe(Recipe updatedRecipe)
    {
        Recipe original = this.GetRecipeById(updatedRecipe.Id);

        original.Title = updatedRecipe.Title != null ? updatedRecipe.Title : original.Title;
        original.Instructions = updatedRecipe.Instructions != null ? updatedRecipe.Instructions : original.Instructions;
        original.Img = updatedRecipe.Img != null ? updatedRecipe.Img : original.Img;
        original.Category = updatedRecipe.Category != null ? updatedRecipe.Category : original.Category;
        Recipe newRecipe = _repo.EditRecipe(original);
        return newRecipe;
    }
}


