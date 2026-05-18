using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Services.Impl
{
    public interface IAuthService
    {
        Task<Boolean> Login(string username, string password);
    }
}
