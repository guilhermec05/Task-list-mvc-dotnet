using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Models;

namespace task.Repositories.Impl
{
    public interface ITaskRepository
    {

        Task<Tasks> GetTaskById(int taskId);

        Task<List<Tasks>> GetTaskListByUserId(int user_id);
        void Add(Tasks task);

        Task Remove(Tasks tasks);
    }
}
