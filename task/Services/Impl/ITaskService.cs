using System.Collections.Generic;
using System.Threading.Tasks;
using task.Domain.Models;

namespace task.Services.Impl
{
    public interface ITaskService
    {

        Task<Tasks> GetTaskById(int tasksId);

        Task<List<Tasks>> GetTaskListByUserId(int user_id);

        Task<List<Tasks>> GetTaskListByName(string search);
        Task<bool> Add(Tasks task);

        Task Update(Tasks task);

        Task Delete(int id);
    }
}
