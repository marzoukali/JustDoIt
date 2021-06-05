using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIS.Todo.Data;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application.UserTodos
{
    public class Create
    {
        public class Command : IRequest
        { 
            public TodoItem TodoItem {get; set;}
        }

        public class Handler : IRequestHandler<Command>
        {
             private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                 _context.TodoItems.Add(request.TodoItem);

                 await _context.SaveChangesAsync();

                 return Unit.Value;
            }
        }
    }
}