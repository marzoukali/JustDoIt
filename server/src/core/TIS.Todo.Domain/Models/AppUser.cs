using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TIS.Todo.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public ICollection<TodoItem> ToDos { get; set; }
    }
}