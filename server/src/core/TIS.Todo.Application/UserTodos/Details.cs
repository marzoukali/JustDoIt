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
        public class Query : IRequest<TodoItem>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, TodoItem>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }


            public async Task<TodoItem> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.TodoItems.FindAsync(request.Id);
            }
        }
        
    }
}