using System;
using System.Collections.Generic;

namespace TIS.Todo.Domain.Models
{
    public class TodoCategory
    {
        public Guid Id  { get; set; }
        public string Title  { get; set; }
        public string Description  { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatorId { get; set; }
        public List<TodoItem> Todos { get; set; }
    }
}