
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
        rec.*
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
}