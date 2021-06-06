using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using TIS.Todo.Data;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application.UserTodos
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        { 
            public TodoItem TodoItem {get; set;}
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor( x => x.TodoItem).SetValidator(new TodoItemValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
             private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                 _context.TodoItems.Add(request.TodoItem);

                 var isCreated = await _context.SaveChangesAsync() > 0;

                 if(!isCreated)
                  return Result<Unit>.Failure("Error happened while creating a new todo item");

                 return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}