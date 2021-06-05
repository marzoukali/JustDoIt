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
            if (!context.TodoCategories.Any())
            {
                var categories = new List<TodoCategory>
                {
                    new TodoCategory
                   {
                      Id = 1,
                      Title = "Technical",
                      Description = "My Technical Todos",
                    },
                    new TodoCategory
                    {
                      Id = 2,
                      Title = "Family",
                      Description = "Family Duites",
                    },
                 };
                await context.TodoCategories.AddRangeAsync(categories);
            }


            if (!context.TodoCategories.Any())
            {
                var todos = new List<TodoItem>
                {
                    new TodoItem
                   {
                      Id = new Guid("a3912bd7-e7e4-437c-8765-1544b16e62fe"),
                      Title = "Finalize Elastic Search!",
                      CreatedAt = DateTime.Now,
                      CategoryId = 1,
                      DueAt = DateTime.Now.AddDays(2),
                      IsComplete = false,
                    },
                    new TodoItem
                    {
                      Id = new Guid("9343119a-1748-453e-9fcb-d26545a8beed"),
                      Title = "Getting a present for my girlfriend!",
                      CreatedAt = DateTime.Now,
                      CategoryId = 2,
                      DueAt = DateTime.Now.AddDays(5),
                      IsComplete = false,
                    },
                 };
                await context.TodoItems.AddRangeAsync(todos);
            }
            
            await context.SaveChangesAsync();
        }
    }
}