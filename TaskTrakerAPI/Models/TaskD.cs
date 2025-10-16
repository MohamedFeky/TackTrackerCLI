using System.ComponentModel.DataAnnotations;

namespace TaskTrakerAPI.Models
{
    public class TaskD
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;    
        [Required]
        [MaxLength(550)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public TaskStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdateedAt { get; set; } = DateTime.Now;


    }
}
