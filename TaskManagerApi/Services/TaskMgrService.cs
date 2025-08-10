using TaskManagerApi.Interfaces.IRepositories;
using TaskManagerApi.Interfaces.IServices;
using TaskManagerApi.Models;

namespace TaskManagerApi.Services
{
    public class TaskMgrService : ITaskMgrService
    {
        private readonly ITaskMgrRepository _taskMgrRepository;
        public TaskMgrService(ITaskMgrRepository taskMgrRepository)
        {
            _taskMgrRepository = taskMgrRepository;
        }
        public async Task DeleteSpecificTask(int taskId)
        {
            await _taskMgrRepository.DeleteSpecificTask(taskId);
        }

        public async Task<TaskMgmt> GetSpecificTask(int taskId)
        {
            return await _taskMgrRepository.GetSpecificTask(taskId);
        }

        public async Task<List<TaskMgmt>> GetTasksToDo()
        {
            return await _taskMgrRepository.GetTasksToDo();
        }

        public async Task<TaskMgmt> SaveTask(TaskMgmt taskMgmt)
        {
            return await _taskMgrRepository.SaveTask(taskMgmt);
        }

        public async Task UpdateTask(TaskMgmt taskMgmt)
        {
            await _taskMgrRepository.UpdateTask(taskMgmt);
        }

        public async Task<bool> ValidateExistingTask(TaskMgmt taskMgmt)
        {
            return await _taskMgrRepository.ValidateExistingTask(taskMgmt);
        }
    }
}
