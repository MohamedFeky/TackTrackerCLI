using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTrakerAPI.Models;
using TaskTrakerAPI.Repositories;
using TaskTrakerAPI.Services;

namespace TaskTrakerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _services;

        public TaskController(ITaskService services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllTasksDto>>> GetAll()
        {
           var tasks = await _services.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetTaskByIdDto>> GetById(int id)
        {
            var task = await _services.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }



        [HttpPost]
        public async Task<ActionResult<GetTaskByIdDto>> Create([FromBody] CreateTaskDto task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTask = await _services.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, task);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteTaskAsync(id);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskDto task)
        {
            await _services.UpdateTaskAsync(id, task);
            return NoContent();
        }


    }
}
