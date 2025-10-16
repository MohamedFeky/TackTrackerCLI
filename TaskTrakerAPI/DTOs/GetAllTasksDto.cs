﻿namespace TaskTrakerAPI.Models
{
    public class GetAllTasksDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateedAt { get; set; }
    }
}
