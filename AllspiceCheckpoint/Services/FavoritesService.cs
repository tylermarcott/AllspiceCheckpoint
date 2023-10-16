using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllspiceCheckpoint.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repo;

    public FavoritesService(FavoritesRepository repo)
    {
        _repo = repo;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        Favorite newFavorite = _repo.CreateFavorite(favoriteData);
        return newFavorite;
    }

    internal void DeleteFavorite(int favoriteId, string accountId)
    {
        Favorite foundFavorite = _repo.GetById(favoriteId);
        if (foundFavorite == null) throw new Exception("Invalid favorite id.");
        if (foundFavorite.AccountId != accountId) throw new Exception("This is not your favorite to delete");
        int rows = _repo.DeleteFavorite(favoriteId);
        if (rows > 1) throw new Exception("Something went wrong");
        if (rows < 1) throw new Exception("Something went way wrong");
    }

    internal List<RecipeFavoriteViewModel> GetFavoritesByAccount(string accountId)
    {
        List<RecipeFavoriteViewModel> myFavorites = _repo.GetFavoritesByAccount(accountId);
        return myFavorites;
    }
}
