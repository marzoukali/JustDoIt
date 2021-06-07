using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoItem>();

            base.OnModelCreating(builder);
        }
    }
}