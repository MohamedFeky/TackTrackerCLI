using TaskTrakerAPI.Models;
using TaskTrakerAPI.Models;
using TaskTrakerAPI.Repositories;

namespace TaskTrakerAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;
        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> CreateTaskAsync(CreateTaskDto createTaskDtoFromRequest)
        {
            var newTask = new TaskD
            {
                Name = createTaskDtoFromRequest.Name,
                Description = createTaskDtoFromRequest.Description,
                Status = (Models.TaskStatus)createTaskDtoFromRequest.Status
            };
            await _repo.CreateAsync(newTask);
            return newTask.Id;
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task != null)
            {
                await _repo.DeleteAsync(id);
            }
        }

        public Task<IEnumerable<GetAllTasksDto>> GetAllTasksAsync()
        {
            var tasks = _repo.GetAllAsync();
            var tasksDto = tasks.Result.Select(t => new GetAllTasksDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Status = (Models.TaskStatus)t.Status,
                CreatedAt = t.CreatedAt,
            });
            return tasksDto;
        }

        public async Task<GetTaskByIdDto> GetTaskByIdAsync(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null) return null;

            return new GetTaskByIdDto 
            { 
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = (Models.TaskStatus)task.Status,
                CreatedAt = task.CreatedAt,
            };
        }



        public async Task UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null)
                return;
            if (updateTaskDto.Name != null)
                task.Name = updateTaskDto.Name;
            if (updateTaskDto.Description != null)
                task.Description = updateTaskDto.Description;
            if (updateTaskDto.Status != null)
                task.Status = updateTaskDto.Status.Value;
            await _repo.UpdateAsync(task);
        }
    }
}
