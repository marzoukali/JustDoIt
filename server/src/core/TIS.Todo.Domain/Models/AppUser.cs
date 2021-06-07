using Microsoft.AspNetCore.Identity;

namespace TIS.Todo.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}