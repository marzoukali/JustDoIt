using Microsoft.EntityFrameworkCore;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoCategory> TodoCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoItem>()
                .HasOne(a => a.Category)
                .WithMany(a => a.Todos)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
           
                base.OnModelCreating(builder);
        }

    }
}