using System.ComponentModel.DataAnnotations;

namespace TaskTrakerAPI.Models
{
    public class DeleteTaskByIdDto
    {
        [Required]
        public int Id { get; set; }
    }
}
