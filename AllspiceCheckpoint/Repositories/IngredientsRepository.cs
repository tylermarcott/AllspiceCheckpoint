


namespace AllspiceCheckpoint.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO ingredients
        (name, quantity, creatorId, recipeId)
        VALUES
        (@name, @quantity, @creatorId, @recipeId);

        SELECT
        ing.*,
        acc.*
        FROM ingredients ing
        JOIN accounts acc ON acc.id = @creatorId
        WHERE ing.id = LAST_INSERT_ID()
        ;";

        Ingredient newIngredient = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
        {
            ingredient.Creator = account;
            return ingredient;
        }, ingredientData).FirstOrDefault();
        return newIngredient;
    }

    internal Ingredient GetById(int ingredientId)
    {
        string sql = @"
        SELECT
        *
        FROM ingredients
        WHERE id = @ingredientId
        ;";
        Ingredient ingredient = _db.Query<Ingredient>(sql, new { ingredientId }).FirstOrDefault();
        return ingredient;
    }

    internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
    {
        string sql = @"
        SELECT
        ing.*,
        acc.*
        FROM ingredients ing
        JOIN accounts acc ON acc.id = ing.creatorId
        WHERE recipeId = @recipeId
        ;";
        List<Ingredient> ingredients = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
        {
            ingredient.Creator = account;
            return ingredient;
        }, new { recipeId }).ToList();
        return ingredients;
    }


    internal int DeleteIngredient(int ingredientId)
    {
        string sql = @"
        DELETE FROM ingredients
        WHERE id = @ingredientId
            LIMIT 1
        ;";
        int rows = _db.Execute(sql, new { ingredientId });
        return rows;
    }
}