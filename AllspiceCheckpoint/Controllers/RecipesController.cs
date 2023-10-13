
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


    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipe newRecipe = _recipesService.CreateRecipe(recipeData);
            return newRecipe;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
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

    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetRecipeById(int recipeId)
    {
        try
        {
            Recipe recipe = _recipesService.GetRecipeById(recipeId);
            return recipe;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // [HttpPost]
    // [Authorize]
    // public ActionResult<Recipe>CreateRecipe([FromBody] recipeData)
    // {
    //     try
    //     {
    //         Recipe recipe = _recipesService.CreateRecipe();
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    // }


}
