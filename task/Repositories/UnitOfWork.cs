using System.Threading.Tasks;
using task.Infrastruct.Data.Context;
using task.Repositories.Impl;

namespace task.Repositories
{
    public class UnitOfWork : IUnityOfWork
    {

        private readonly AppDbContext _context;

        public IUserRepository Users { get; }

        public ITaskRepository Task { get; }

        public UnitOfWork(
             AppDbContext context,
            IUserRepository userRepository,
            ITaskRepository taskRepository
         )
        {
            _context = context;
            Users = userRepository;
            Task = taskRepository;

        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}