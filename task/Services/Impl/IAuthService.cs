using System;
using System.Threading.Tasks;

namespace task.Services.Impl
{
    public interface IAuthService
    {
        Task<Boolean> Login(string username, string password);
    }
}
