using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using task.Infrastruct.Data.Context;
using task.Domain.Models;
using task.Repositories.Impl;

namespace task.Repositories
{
    public class TaskRepository : RepositoryBase, ITaskRepository
    {
        public TaskRepository(AppDbContext context) : base(context)
        {
        }

        public void Add(Tasks tasks)
        {
            _context.Tasks.Add(tasks);
        }

        public async Task<Tasks> GetTaskById(int taskId)
        {
            return await _context.Tasks.FirstOrDefaultAsync(x => x.Id == taskId);
        }

        public async Task<List<Tasks>> GetTaskListByName(string search)
        {
            return await _context.Tasks.Where(x => x.Description.Contains(search)
            || x.Title.Contains(search)).ToListAsync();
        }

        public async Task<List<Tasks>> GetTaskListByUserId(int user_id)
        {
            return await _context.Tasks.Where(x => x.UserId == user_id).ToListAsync();
        }

        public async Task Remove(Tasks tasks)
        {
            _context.Tasks.Remove(tasks);
        }
    }
}