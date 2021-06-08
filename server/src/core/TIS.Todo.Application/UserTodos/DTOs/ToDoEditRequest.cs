using System;

namespace TIS.Todo.Api.DTOs
{
    public class ToDoEditRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueAt { get; set; }
        public bool IsComplete { get; set; }
        public string Category { get; set; }
    }
}