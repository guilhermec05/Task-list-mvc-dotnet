using System.Collections.Generic;
using System.Threading.Tasks;
using task.Domain.Models;

namespace task.Repositories.Impl
{
    public interface ITaskRepository
    {

        Task<Tasks> GetTaskById(int taskId);

        Task<List<Tasks>> GetTaskListByUserId(int user_id);

        Task<List<Tasks>> GetTaskListByName(string search);
        void Add(Tasks task);

        Task Remove(Tasks tasks);
    }
}
