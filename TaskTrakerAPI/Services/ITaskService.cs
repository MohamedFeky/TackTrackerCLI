using TaskTrakerAPI.Models;

using TaskTrakerAPI.Repositories;

namespace TaskTrakerAPI.Services
{
    public interface ITaskService
    {

        public Task<GetTaskByIdDto> CreateTaskAsync(CreateTaskDto createTaskDto);

        public Task UpdateTaskAsync(int id,UpdateTaskDto updateTaskDto);

        public Task DeleteTaskAsync(int id);

        public Task<GetTaskByIdDto> GetTaskByIdAsync(int id);
        public Task<IEnumerable<GetAllTasksDto>> GetAllTasksAsync();



    }
}
