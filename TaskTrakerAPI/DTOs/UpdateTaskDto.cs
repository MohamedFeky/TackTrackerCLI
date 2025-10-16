using System.ComponentModel.DataAnnotations;

namespace TaskTrakerAPI.Models
{
    public class UpdateTaskDto
    {

        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(550)]
        public string? Description { get; set; }

        public TaskStatus? Status { get; set; }


    }
}
