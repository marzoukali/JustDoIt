using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TIS.Todo.Api.Attributes;
using TIS.Todo.Api.DTOs;
using TIS.Todo.Application.UserTodos;

namespace TIS.Todo.Api.Controllers
{
    [Route("api/{user-id}/todos")]
    [AuthorizeUserForOwnedResources]
    public class UserTodosController : BaseApiController
    {
        private readonly ILogger<UserTodosController> _logger;

        public UserTodosController(ILogger<UserTodosController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetTodoItems()
        {
            var userId = RouteData.Values["user-id"]?.ToString();

            return HandleResult(await Mediator.Send(new List.Query {UserId = userId}));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query {Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItem(ToDoCreateRequest todo)
        {
            var userId = RouteData.Values["user-id"]?.ToString();

            return HandleResult(await Mediator.Send(new Create.Command {TodoItem = todo, UserId = userId}));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditTodoItem(Guid id, ToDoEditRequest todo)
        {
            var userId = RouteData.Values["user-id"]?.ToString();
            var todoId = RouteData.Values["id"]?.ToString();


            return HandleResult(
                await Mediator.Send(new Edit.Command {TodoItem = todo, UserId = userId, TodoId = todoId}));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command {Id = id}));
        }
    }
}