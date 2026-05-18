using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using task.Models;
using task.Repositories.Impl;
using task.Services.Impl;
using task.Util;

namespace task.Services
{
    public class UserServices : BaseService , IUserServices
    {
        public UserServices(IUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }

        public async Task<int> CreateUser(User user)
        {

            user.Password = PasswordHandler.Hash(user.Password);

            _unitOfWork.Users.Add(user);

            await _unitOfWork.CommitAsync();

            return 1;
        }

        public async  Task<User> GetUserByEmail(string email)
        {
           return await _unitOfWork.Users.GetByEmail(email) ;
        }
    }
}