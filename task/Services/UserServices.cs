using System.Threading.Tasks;
using task.Domain.Models;
using task.Repositories.Impl;
using task.Services.Impl;
using task.Shared.Util;

namespace task.Services
{
    public class UserServices : BaseService, IUserServices
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

        public async Task<User> GetUser(int id)
        {
            return await _unitOfWork.Users.Get(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _unitOfWork.Users.GetByEmail(email);
        }

        public async Task Update(User user)
        {
            await _unitOfWork.Users.Update(user);

            await _unitOfWork.CommitAsync();
        }
    }
}