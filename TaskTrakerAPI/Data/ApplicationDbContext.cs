using Microsoft.EntityFrameworkCore;
using TaskTrakerAPI.Models;

namespace TaskTrakerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskD> TaskDs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}
