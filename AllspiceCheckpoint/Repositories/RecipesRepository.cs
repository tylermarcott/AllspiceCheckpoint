






namespace AllspiceCheckpoint.Repositories;
public class RecipesRepository
{
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO recipes
        (title, instructions, img, category, creatorId)
        VALUES
        (@title, @instructions, @img, @category, @creatorId);

        SELECT
        rec.*,
        acc.*
        FROM recipes rec
        JOIN accounts acc ON acc.id = rec.creatorId
        WHERE rec.id = LAST_INSERT_ID()
        ;";
        Recipe newRecipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, recipeData).FirstOrDefault();
        return newRecipe;
    }

    internal List<Recipe> GetAllRecipes()
    {
        string sql = @"
        SELECT
        rec.*,
        acc.*
        FROM recipes rec
        JOIN accounts acc ON acc.id = rec.creatorId
        ;";
        List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }).ToList();
        return recipes;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        string sql = @"
        SELECT
        rec.*,
        acc.*
        FROM recipes rec
        JOIN accounts acc ON rec.creatorId = acc.id
        WHERE rec.id = @recipeId
        ;";
        Recipe foundRecipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
        {
            recipe.Creator = creator;
            return recipe;
        }, new { recipeId }).FirstOrDefault();
        return foundRecipe;
    }

    internal int DeleteRecipe(int recipeId)
    {
        string sql = @"
        DELETE FROM recipes
        WHERE id = @recipeId
        LIMIT 1
        ;";
        int rows = _db.Execute(sql, new { recipeId });
        return rows;
    }

    internal Recipe EditRecipe(Recipe recipeToUpdate)
    {
        string sql = @"
        UPDATE recipes
        SET
        title = @title,
        instructions = @instructions,
        img = @img,
        category = @category
        WHERE id = @id;
        SELECT * FROM recipes WHERE id = @id
        ;";
        Recipe recipe = _db.Query<Recipe>(sql, recipeToUpdate).FirstOrDefault();
        return recipe;
    }
}
