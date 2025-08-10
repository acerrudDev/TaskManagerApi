using Microsoft.EntityFrameworkCore;
using System.Threading;
using TaskManagerApi.Data.Context;
using TaskManagerApi.Interfaces.IRepositories;
using TaskManagerApi.Models;

namespace TaskManagerApi.Data.Repositories
{
    public class TaskMgrRepository : ITaskMgrRepository
    {
        private readonly AppDbContext _context;
        public TaskMgrRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteSpecificTask(int taskId)
        {
            var specificTask = await _context.TasksToDo.FindAsync(taskId);
            if (specificTask != null)
            {
                _context.TasksToDo.Remove(specificTask);
                await _context.SaveChangesAsync();
            }            
        }

        public async Task<TaskMgmt> GetSpecificTask(int taskId)
        {
            return await _context.TasksToDo.FindAsync(taskId); ;
        }

        public async Task<List<TaskMgmt>> GetTasksToDo()
        {
            return await _context.TasksToDo.ToListAsync();
        }

        public async Task<TaskMgmt> SaveTask(TaskMgmt taskMgmt)
        {
            _context.TasksToDo.Add(taskMgmt);
            await _context.SaveChangesAsync();
            return taskMgmt;
        }

        public async Task UpdateTask(TaskMgmt taskMgmt)
        {
            _context.Entry(taskMgmt).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistingTask(TaskMgmt taskMgmt)
        {
            return await _context.TasksToDo.AnyAsync(t => t.Id == taskMgmt.Id);
        }
    }
}
