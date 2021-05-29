using System;

namespace TIS.Todo.Domain.Models
{
    public class TodoItem
    {
        public Guid Id  { get; set; }
        public string Title  { get; set; }
         public DateTime CreatedAt { get; set; }
        public DateTimeOffset? DueAt { get; set; }
        public bool IsComplete { get; set; }
        public Guid CreatorId { get; set; }
        public Guid CategoryId { get; set; }
        public TodoCategory Category { get; set; }
    }
}