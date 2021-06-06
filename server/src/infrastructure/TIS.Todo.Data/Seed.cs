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
            if (!context.TodoItems.Any())
            {
                var todos = new List<TodoItem>
                {
                    new TodoItem
                   {
                      Id = new Guid("a3912bd7-e7e4-437c-8765-1544b16e62fe"),
                      Title = "Finalize Elastic Search!",
                      Description = "Finish pluralsight courses and make a poc.",
                      CreatedAt = DateTime.Now,
                      Category = TodoCategory.Technical.ToString(),
                      DueAt = DateTime.Now.AddDays(2),
                      IsComplete = false,
                    },
                    new TodoItem
                    {
                      Id = new Guid("9343119a-1748-453e-9fcb-d26545a8beed"),
                      Title = "Getting a present for my girlfriend!",
                      Description = "bla bla",
                      CreatedAt = DateTime.Now,
                      Category = TodoCategory.Family.ToString(),
                      DueAt = DateTime.Now.AddDays(5),
                      IsComplete = true,
                    },
                    new TodoItem
                    {
                      Id = new Guid("27cad04e-56b6-43e9-8517-17eb38c52129"),
                      Title = "Solve 3 leetcode medium problems!",
                      Description = "dynamic programming questions and backtracking",
                      CreatedAt = DateTime.Now,
                      Category = TodoCategory.Technical.ToString(),
                      DueAt = DateTime.Now.AddDays(7),
                      IsComplete = false,
                    },
                    new TodoItem
                    {
                      Id = new Guid("794fc853-f73c-472e-b33f-9d7d7622344d"),
                      Title = "Call my friends that i missed their call",
                      Description = "Important to be done as soon as possible.",
                      CreatedAt = DateTime.Now,
                      Category = TodoCategory.Friends.ToString(),
                      DueAt = DateTime.Now.AddDays(3),
                      IsComplete = false,
                    },
                 };
                await context.TodoItems.AddRangeAsync(todos);
            }
            
            await context.SaveChangesAsync();
        }
    }
}