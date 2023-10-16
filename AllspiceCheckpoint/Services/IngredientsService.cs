



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

    internal void DeleteIngredient(int ingredientId)
    {
        //TODO finish this.
        // Ingredient foundIngredient = 
    }
}
