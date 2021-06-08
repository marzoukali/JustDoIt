using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIS.Todo.Application.Interfaces.IRepositories;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application.UserTodos
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IAsyncRepository<TodoItem> _toDoRepository;

            public Handler(IAsyncRepository<TodoItem> toDoRepository)
            {
                _toDoRepository = toDoRepository;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var item = await _toDoRepository.GetByIdAsync(request.Id);

                if (item == null) return null;

                var isDeleted = await _toDoRepository.DeleteAsync(item) > 0;

                if (!isDeleted)
                    return Result<Unit>.Failure("Error happened while deleting todo item");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}