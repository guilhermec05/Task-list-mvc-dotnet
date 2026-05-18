using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using task.Models;
using task.Repositories.Impl;
using task.Services.Impl;

namespace task.Services
{
    public class TaskService : BaseService, ITaskService
    {
        public TaskService(IUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }

        public async Task<bool> Add(Tasks task)
        {
            _unitOfWork.Task.Add(task);

            await _unitOfWork.CommitAsync();

            return true;   
        }

        public async Task<List<Tasks>> GetTaskListByUserId(int user_id)
        {
            return await _unitOfWork.Task.GetTaskListByUserId(user_id);
        }
    }
}