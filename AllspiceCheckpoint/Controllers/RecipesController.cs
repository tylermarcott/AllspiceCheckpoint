
namespace AllspiceCheckpoint.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipesController : ControllerBase
{
    private readonly RecipesService _recipesService;
    private readonly Auth0Provider _auth0;

    public RecipesController(RecipesService recipesService, Auth0Provider auth0)
    {
        _recipesService = recipesService;
        _auth0 = auth0;
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetAllRecipes()
    {
        try
        {
            List<Recipe> recipes = _recipesService.GetAllRecipes();
            return recipes;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}
