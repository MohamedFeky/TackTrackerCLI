using TaskTrakerAPI.Models;

namespace TaskTrakerAPI.Repositories
{
    public interface ITaskRepository
    {
        public Task CreateAsync(TaskD task);

        public Task UpdateAsync(TaskD task);

        public Task DeleteAsync(int id);

        public Task<TaskD> GetByIdAsync(int id);
        public Task<IEnumerable<TaskD>> GetAllAsync();
        public Task SaveAsync();
    }
}
