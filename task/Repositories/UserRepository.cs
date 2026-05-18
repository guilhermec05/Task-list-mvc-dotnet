using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using task.Context;
using task.Models;
using task.Repositories.Impl;

namespace task.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public void Add(User user)
        {
            _context.Users.Add(user);


        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}