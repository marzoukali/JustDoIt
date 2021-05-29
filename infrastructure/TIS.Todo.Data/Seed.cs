using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.TodoCategories.Any()) return;
            
            var categories = new List<TodoCategory>
            {
                new TodoCategory
                {
                    Title = "Technical",
                    CreatedAt = DateTime.Now.AddMonths(-2),
                    Description = "My Technical Todos",
                },
                new TodoCategory
                {
                    Title = "Family",
                    CreatedAt = DateTime.Now.AddMonths(-2),
                    Description = "Family Tasks",
                },
            };
            await context.TodoCategories.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }
    }
}