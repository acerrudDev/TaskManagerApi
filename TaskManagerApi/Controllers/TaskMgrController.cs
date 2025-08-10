using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TaskManagerApi.Data;
using TaskManagerApi.Data.Context;
using TaskManagerApi.Interfaces.IRepositories;
using TaskManagerApi.Interfaces.IServices;
using TaskManagerApi.Models;

namespace TaskManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskMgrController: ControllerBase
    {
        private readonly ITaskMgrService _taskMgrService;
        public TaskMgrController(ITaskMgrService taskMgrService)
        {
            _taskMgrService = taskMgrService;
        }

        [HttpGet]
        [Route("gettaskstodo/")]
        public async Task<ActionResult<IEnumerable<TaskMgmt>>> GetTasksToDo()
        {
            try
            {
                var taskList = await _taskMgrService.GetTasksToDo();
                return Ok(taskList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("getspecifictask/{id}")]
        public async Task<ActionResult<TaskMgmt>> GetSpecificTask(int id)
        {
            var specificTask = await _taskMgrService.GetSpecificTask(id);
            if (specificTask == null) return NotFound();
            return Ok(specificTask);
        }

        [HttpPost]
        [Route("savetask/")]
        public async Task<ActionResult<TaskMgmt>> SaveTask([FromBody] TaskMgmt newTaskData)
        {
            var validateExistingTask = await _taskMgrService.ValidateExistingTask(newTaskData);
            if(validateExistingTask) 
            {
                return BadRequest("The task " + newTaskData.Title + " already exists in our systems");
            }
            newTaskData.Completed = true;
            newTaskData.CreatedDate = DateTime.Now;
            newTaskData.LastModified = DateTime.Now;
            await _taskMgrService.SaveTask(newTaskData);
            return Ok(new { message = "Task " + newTaskData.Title + " Successfully created" });
        }

        [HttpPut]
        [Route("savetask/{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskMgmt taskData)
        {
            if (id != taskData.Id) return BadRequest();
            taskData.LastModified = DateTime.Now;
            await _taskMgrService.UpdateTask(taskData);    
            return Ok(new { message = "Data Successfully Modified" });
        }

        [HttpDelete]
        [Route("removetask/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskMgrService.DeleteSpecificTask(id);
            return Ok(new { message = "Data Successfully Deleted" });
        }
    }
}
