using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace AllspiceCheckpoint.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
        INSERT INTO favorites
        (recipeId, accountId)
        VALUES
        (@recipeId, @accountId);
        SELECT LAST_INSERT_ID()
        ;";

        int lastInsertId = _db.ExecuteScalar<int>(sql, favoriteData);
        favoriteData.Id = lastInsertId;
        return favoriteData;
    }

    internal Favorite GetById(int favoriteId)
    {
        string sql = @"
        SELECT
        *
        FROM favorites
        WHERE id = @favoriteId
        ;";
        Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
        return favorite;
    }

    internal List<RecipeFavoriteViewModel> GetFavoritesByAccount(string accountId)
    {
        string sql = @"
        SELECT
        fav.*,
        rec.*
        FROM favorites fav
        JOIN recipes rec ON rec.id = fav.recipeId
        WHERE fav.accountId = @accountId
        ;";
        List<RecipeFavoriteViewModel> myRecipes = _db.Query<Favorite, RecipeFavoriteViewModel, RecipeFavoriteViewModel>(sql, (fav, recipe) =>
        {
            recipe.FavoriteId = fav.Id;
            recipe.AccountId = fav.AccountId;
            return recipe;
        }, new { accountId }).ToList();
        return myRecipes;
    }

    internal int DeleteFavorite(int favoriteId)
    {
        string sql = @"
        DELETE FROM favorites
        WHERE id = @favoriteId
            LIMIT 1 
        ;";
        int rows = _db.Execute(sql, new { favoriteId });
        return rows;
    }
}
