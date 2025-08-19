using System;

namespace TaskManagerApp
{
    public class TaskItem(int id, string title, string? description = null)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string? Description { get; set; } = description;
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}