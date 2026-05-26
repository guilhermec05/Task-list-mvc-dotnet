using System.Threading.Tasks;
using task.Domain.Models;

namespace task.Repositories.Impl
{
    public interface IUserRepository
    {


        Task<User> Get(int id);

        Task<User> GetByEmail(string email);

        void Add(User user);

        Task Update(User user);
    }
}
