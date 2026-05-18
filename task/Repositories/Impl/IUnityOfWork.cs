using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Models;

namespace task.Repositories.Impl
{
    public interface IUnityOfWork : IDisposable
    {
        IUserRepository Users { get; }

        ITaskRepository Task {  get; }

        Task<int> CommitAsync();

    }
}
