using Microsoft.EntityFrameworkCore;
using TaskTrakerAPI.Data;
using TaskTrakerAPI.Models;

namespace TaskTrakerAPI.Repositories
{

    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskD>> GetAllAsync()
        {
            return await _context.TaskDs.ToListAsync();
        }

        public async Task CreateAsync(TaskD task)
        {
            await _context.TaskDs.AddAsync(task);
        }

        public Task UpdateAsync(TaskD task)
        {
            _context.TaskDs.Update(task);
            return Task.CompletedTask;
        }
        public async Task DeleteAsync(int id)
        {
            var task = await _context.TaskDs.FindAsync(id);

            if (task != null)
            {
                _context.TaskDs.Remove(task);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TaskD> GetByIdAsync(int id)
        {
            var task = await _context.TaskDs.FindAsync(id);
            return task;
        }
    }
}

