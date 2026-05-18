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

        Task<List<Tasks>> GetTaskListByUserId(int user_id);
        Task<bool> Add(Tasks task);
    }
}
