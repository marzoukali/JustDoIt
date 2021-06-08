using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any() && !context.TodoItems.Any())
            {
                var userResult = await userManager.CreateAsync(new AppUser()
                {
                    DisplayName = "test",
                    UserName = "test",
                    Email = "test@test.com",
                    Id = "faef4f78-fab3-4176-96f0-5cfa2f2beab8"
                }, "Pwd123");


                if (userResult.Succeeded)
                {
                    var user = await userManager.FindByIdAsync("faef4f78-fab3-4176-96f0-5cfa2f2beab8");

                    if (user != null)
                    {
                        var todos = new List<TodoItem>
                        {
                            new()
                            {
                                Id = new Guid("a3912bd7-e7e4-437c-8765-1544b16e62fe"),
                                Title = "Finalize Elastic Search!",
                                Description = "Finish pluralsight courses and make a poc.",
                                CreatedAt = DateTime.Now,
                                LastUpdatedAt = DateTime.Now,
                                Category = TodoCategory.Technical.ToString(),
                                DueAt = DateTime.Now.AddDays(2),
                                IsComplete = false,
                                UserId = user.Id,
                                User = user
                            },
                            new()
                            {
                                Id = new Guid("9343119a-1748-453e-9fcb-d26545a8beed"),
                                Title = "Getting a present for my girlfriend!",
                                Description = "bla bla",
                                CreatedAt = DateTime.Now,
                                LastUpdatedAt = DateTime.Now,
                                Category = TodoCategory.Family.ToString(),
                                DueAt = DateTime.Now.AddDays(5),
                                IsComplete = true,
                                UserId = user.Id,
                                User = user
                            },
                            new()
                            {
                                Id = new Guid("27cad04e-56b6-43e9-8517-17eb38c52129"),
                                Title = "Solve 3 leetcode medium problems!",
                                Description = "dynamic programming questions and backtracking",
                                CreatedAt = DateTime.Now,
                                LastUpdatedAt = DateTime.Now,
                                Category = TodoCategory.Technical.ToString(),
                                DueAt = DateTime.Now.AddDays(7),
                                IsComplete = false,
                                UserId = user.Id,
                                User = user
                            },
                            new()
                            {
                                Id = new Guid("794fc853-f73c-472e-b33f-9d7d7622344d"),
                                Title = "Call my friends that i missed their call",
                                Description = "Important to be done as soon as possible.",
                                CreatedAt = DateTime.Now,
                                LastUpdatedAt = DateTime.Now,
                                Category = TodoCategory.Friends.ToString(),
                                DueAt = DateTime.Now.AddDays(3),
                                IsComplete = false,
                                UserId = user.Id,
                                User = user
                            }
                        };
                        await context.TodoItems.AddRangeAsync(todos);
                        await context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}