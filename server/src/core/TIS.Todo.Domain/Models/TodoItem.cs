using System;

namespace TIS.Todo.Domain.Models
{
    public class TodoItem : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime? DueAt { get; set; }
        public bool IsComplete { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string Category { get; set; }
    }
}