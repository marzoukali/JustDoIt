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
        public class Command : IRequest<Result<Unit>>
        { 
            public Guid Id {get; set;}
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
                var item =  await _context.TodoItems.FindAsync(request.Id);
                
                if(item == null) return null;

                 _context.Remove(item);

                var isDeleted = await _context.SaveChangesAsync() > 0;

                 if(!isDeleted)
                  return Result<Unit>.Failure("Error happened while deleting todo item");

                 return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}