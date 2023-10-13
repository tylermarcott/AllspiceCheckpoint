


namespace AllspiceCheckpoint.Repositories;
public class RecipesRepository
{
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal List<Recipe> GetAllRecipes()
    {
        string sql = @"
        SELECT
        rec.*,
        act.*
        From recipes rec
        JOIN accounts acc ON acc.id = rec.creatorId
        ;";
        List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }).ToList();
        return recipes;
    }
}
