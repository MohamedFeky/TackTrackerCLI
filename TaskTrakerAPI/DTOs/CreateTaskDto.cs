using System.ComponentModel.DataAnnotations;

namespace TaskTrakerAPI.Models
{
    public class CreateTaskDto
    {

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(550)]
        public required string Description { get; set; }

        [Required]
        public TaskStatus Status { get; set; }


    }
}
