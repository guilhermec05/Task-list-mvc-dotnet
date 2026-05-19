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

        public async Task Delete(int id)
        {
            Tasks task1 = await _unitOfWork.Task.GetTaskById(id);

            if (task1 == null)
            {
                throw new Exception(
            "Task não encontrada");
            }

            await _unitOfWork.Task.Remove(task1);

            await _unitOfWork.CommitAsync();
        }

        public async  Task<Tasks> GetTaskById(int tasksId)
        {
            return await _unitOfWork.Task.GetTaskById(tasksId);
        }

        public async Task<List<Tasks>> GetTaskListByUserId(int user_id)
        {
            return await _unitOfWork.Task.GetTaskListByUserId(user_id);
        }

        public async Task Update(Tasks task)
        {
            Tasks task1 = await _unitOfWork.Task.GetTaskById(task.Id);

            if(task1 == null){
                throw new Exception(
            "Task não encontrada");
            }

            task1.State = task.State;
            task1.Title = task.Title;
            task1.Description = task.Description;
            task1.DueDate = task.DueDate;

            await _unitOfWork.CommitAsync();
        }
    }
}