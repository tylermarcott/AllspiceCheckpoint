

namespace AllspiceCheckpoint.Repositories;
public class RecipesRepository
{
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }
}
