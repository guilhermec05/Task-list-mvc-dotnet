using System.Threading.Tasks;
using task.Domain.Models;

namespace task.Services.Impl
{
    public interface IUserServices
    {
        Task<User> GetUser(int id);
        Task<int> CreateUser(User user);
        Task<User> GetUserByEmail(string email);

        Task Update(User user);
    }
}
