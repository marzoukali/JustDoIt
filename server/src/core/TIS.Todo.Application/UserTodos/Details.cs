using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIS.Todo.Data;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application.UserTodos
{
    public class Details
    {
        public class Query : IRequest<Result<TodoItem>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<TodoItem>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }


            public async Task<Result<TodoItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                var todoItem = await _context.TodoItems.FindAsync(request.Id);

                return Result<TodoItem>.Success(todoItem);
            }
        }
        
    }
}