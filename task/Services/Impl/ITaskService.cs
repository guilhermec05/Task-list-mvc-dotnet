using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Models;

namespace task.Services.Impl
{
    public interface ITaskService
    {

        Task<Tasks> GetTaskById(int tasksId);

        Task<List<Tasks>> GetTaskListByUserId(int user_id);
        Task<bool> Add(Tasks task);

        Task Update(Tasks task);

        Task Delete(int id);
    }
}
