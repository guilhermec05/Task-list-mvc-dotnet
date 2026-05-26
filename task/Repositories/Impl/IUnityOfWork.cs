using System;
using System.Threading.Tasks;

namespace task.Repositories.Impl
{
    public interface IUnityOfWork : IDisposable
    {
        IUserRepository Users { get; }

        ITaskRepository Task { get; }

        Task<int> CommitAsync();

    }
}
