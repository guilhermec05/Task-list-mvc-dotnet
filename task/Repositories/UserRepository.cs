using System;
using System.Data.Entity;
using System.Threading.Tasks;
using task.Context;
using task.Domain.Models;
using task.Repositories.Impl;
using task.Util;

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

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task Update(User user)
        {
            var userModel = await Get(user.Id);

            if (userModel == null) { 
                throw new Exception("User not found");
            }

            userModel.Name = user.Name;
            userModel.Email = user.Email;

            if (user.Password != null && user.Password != string.Empty)
            {
                userModel.Password = PasswordHandler.Hash(user.Password);
            }


        }
    }
}