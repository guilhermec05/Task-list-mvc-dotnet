using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Models;

namespace task.Repositories.Impl
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);

        void Add(User user);
    }
}
