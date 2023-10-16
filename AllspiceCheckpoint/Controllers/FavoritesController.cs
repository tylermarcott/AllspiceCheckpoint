using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AllspiceCheckpoint.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
    private readonly FavoritesService _favoritesService;
    private readonly Auth0Provider _auth;

    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth)
    {
        _favoritesService = favoritesService;
        _auth = auth;
    }
}
