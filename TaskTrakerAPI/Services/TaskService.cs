using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<GetTaskByIdDto> CreateTaskAsync(CreateTaskDto createTaskDtoFromRequest)
        {
            var newTask = new TaskD
            {
                Name = createTaskDtoFromRequest.Name,
                Description = createTaskDtoFromRequest.Description,
                Status = createTaskDtoFromRequest.Status
            };
            await _repo.CreateAsync(newTask);
            await _repo.SaveAsync();
            var result = new GetTaskByIdDto
            {
                Id = newTask.Id,
                Name = newTask.Name,
                Description = newTask.Description,
                Status = newTask.Status,
                CreatedAt = newTask.CreatedAt
            };

            return result;

        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task != null)
            {
                await _repo.DeleteAsync(id);
                await _repo.SaveAsync();
            }
        }

        public async Task<IEnumerable<GetAllTasksDto>> GetAllTasksAsync()
        {
            var tasks = await _repo.GetAllAsync();

            return tasks.Select(t => new GetAllTasksDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Status = t.Status,
                CreatedAt = t.CreatedAt
            });
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
                Status = task.Status,
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
            await _repo.SaveAsync();
        }
    }
}
