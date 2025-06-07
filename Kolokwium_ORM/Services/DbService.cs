using Kolokwium_ORM.Data;

namespace Kolokwium_ORM.Services;

public class DbService:IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
}