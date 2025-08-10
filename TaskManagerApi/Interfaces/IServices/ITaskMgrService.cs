using TaskManagerApi.Models;

namespace TaskManagerApi.Interfaces.IServices
{
    public interface ITaskMgrService
    {
        Task<List<TaskMgmt>> GetTasksToDo();
        Task<bool> ValidateExistingTask(TaskMgmt taskMgmt);
        Task<TaskMgmt> SaveTask(TaskMgmt taskMgmt);
        Task UpdateTask(TaskMgmt taskMgmt);
        Task DeleteSpecificTask(int taskId);
        Task<TaskMgmt> GetSpecificTask(int taskId);
    }
}
