using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using task.Context;
using task.Models;
using task.Repositories.Impl;

namespace task.Repositories
{
    public class TaskRepository : RepositoryBase ,ITaskRepository
    {
        public TaskRepository(AppDbContext context) : base(context)
        {
        }

        public void Add(Tasks tasks)
        {
           _context.Tasks.Add(tasks);
        }

        public async  Task<List<Tasks>> GetTaskListByUserId(int user_id)
        {
            return await _context.Tasks.Where(x => x.UserId == user_id).ToListAsync();
        }
    }
}