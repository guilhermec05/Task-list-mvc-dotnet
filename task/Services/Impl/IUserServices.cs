using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Models;

namespace task.Services.Impl
{
    public interface IUserServices
    {
        Task<int> CreateUser(User user);
        Task<User> GetUserByEmail(string email);
    }
}
