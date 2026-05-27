using task.Infrastruct.Data.Context;

namespace task.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly AppDbContext _context;

        protected RepositoryBase(AppDbContext context)
        {
            _context = context;
        }
    }
}