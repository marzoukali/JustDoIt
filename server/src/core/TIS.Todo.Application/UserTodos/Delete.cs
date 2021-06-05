using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIS.Todo.Data;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application.UserTodos
{
    public class Delete
    {
        public class Command : IRequest
        { 
            public Guid Id {get; set;}
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
                var item =  await _context.TodoItems.FindAsync(request.Id);

                 _context.Remove(item);

                await _context.SaveChangesAsync();

                 return Unit.Value;
            }
        }
    }
}