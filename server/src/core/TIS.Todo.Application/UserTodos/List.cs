using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TIS.Todo.Data;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application.UserTodos
{
    public class List
    {
        public class Query : IRequest<List<TodoItem>>{}

        public class Handler : IRequestHandler<Query, List<TodoItem>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<TodoItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.TodoItems.ToListAsync();
            }
        }
    }
}