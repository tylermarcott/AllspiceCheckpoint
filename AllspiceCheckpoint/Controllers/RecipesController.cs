
namespace AllspiceCheckpoint.Controllers;

public class RecipesController
{
    private readonly RecipesService _recipesService;

    public RecipesController(RecipesService recipesService)
    {
        _recipesService = recipesService;
    }
}
