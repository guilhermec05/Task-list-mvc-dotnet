using System.Threading.Tasks;
using task.Domain.Models;
using task.Repositories.Impl;
using task.Services.Impl;
using task.Shared.Util;

namespace task.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnityOfWork _unitOfWork;

        public AuthService(IUnityOfWork unityOfWork)
        {
            _unitOfWork = unityOfWork;
        }

        public async Task<bool> Login(string email, string password)
        {

            User user = await _unitOfWork.Users.GetByEmail(email);

            if (user != null && PasswordHandler.CheckPassword(password, user.Password))
            {

                return true;
            }

            return false;

        }

    }
}