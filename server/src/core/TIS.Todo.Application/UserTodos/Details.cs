using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIS.Todo.Application.Interfaces.IRepositories;
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
            private readonly IAsyncRepository<TodoItem> _toDoRepository;

            public Handler(IAsyncRepository<TodoItem> toDoRepository)
            {
                _toDoRepository = toDoRepository;
            }


            public async Task<Result<TodoItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                var todoItem = await _toDoRepository.GetByIdAsync(request.Id);
                return Result<TodoItem>.Success(todoItem);
            }
        }
    }
}