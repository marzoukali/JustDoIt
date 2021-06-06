using FluentValidation;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application.UserTodos
{
    public class TodoItemValidator : AbstractValidator<TodoItem>
    {
        public TodoItemValidator()
        {
            RuleFor( x => x.Title).NotEmpty();
            RuleFor( x => x.CreatedAt).NotEmpty();
        }
    }
}