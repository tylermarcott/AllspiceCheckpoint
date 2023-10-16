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

}
