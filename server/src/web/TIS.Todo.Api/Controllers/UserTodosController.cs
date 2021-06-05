using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TIS.Todo.Application.UserTodos;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Api.Controllers
{
    public class UserTodosController : BaseApiController
    {
        private readonly ILogger<UserTodosController> _logger;
        public UserTodosController(ILogger<UserTodosController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
           return  Ok(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(Guid id)
        {
           return  Ok(await Mediator.Send(new Details.Query{Id = id}));
        }

        [HttpPost]
        public async Task<ActionResult> CreateTodoItem(TodoItem todo)
        {
           return  Ok(await Mediator.Send(new Create.Command{TodoItem = todo}));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> EditTodoItem(Guid id, TodoItem todo)
        {
            todo.Id = id;
           return  Ok(await Mediator.Send(new Edit.Command{TodoItem = todo}));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoItem(Guid id)
        {
           return  Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}