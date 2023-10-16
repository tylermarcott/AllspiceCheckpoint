



namespace AllspiceCheckpoint.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repo;

    public IngredientsService(IngredientsRepository repo)
    {
        _repo = repo;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient newIngredient = _repo.CreateIngredient(ingredientData);
        return newIngredient;
    }

    internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
    {
        List<Ingredient> ingredients = _repo.GetIngredientsByRecipe(recipeId);
        return ingredients;
    }

    internal void DeleteIngredient(int ingredientId, string userId)
    {
        Ingredient foundIngredient = _repo.GetById(ingredientId);
        if (foundIngredient == null) throw new Exception("Invalid ingredient id!");
        if (foundIngredient.CreatorId != userId) throw new Exception("This is not your ingredient to delete.");
        int rows = _repo.DeleteIngredient(ingredientId);
        if (rows < 1) throw new Exception("LESS than 1 row deleted.");
        if (rows > 1) throw new Exception("MORE than 1 row deleted.");
    }
}
