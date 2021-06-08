using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using TIS.Todo.Api.DTOs;
using TIS.Todo.Application.Interfaces.IRepositories;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application.UserTodos
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ToDoEditRequest TodoItem { get; set; }
            public string UserId { get; set; }
            public string TodoId { get; set; }
        }

        public class TodoItemEditValidator : AbstractValidator<ToDoEditRequest>
        {
            public TodoItemEditValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.UserId).NotEmpty();
                RuleFor(x => x.TodoId).NotEmpty();
                RuleFor(x => x.TodoItem).SetValidator(new TodoItemEditValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IMapper _mapper;
            private readonly IAsyncRepository<TodoItem> _toDoRepository;


            public Handler(IMapper mapper, IAsyncRepository<TodoItem> toDoRepository)
            {
                _mapper = mapper;
                _toDoRepository = toDoRepository;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var item = await _toDoRepository.GetByIdAsync(Guid.Parse(request.TodoId));

                if (item == null) return null;

                _mapper.Map(request.TodoItem, item);
                item.LastUpdatedAt = DateTime.Now;
                var isUpdated = await _toDoRepository.UpdateAsync(item) > 0;


                if (!isUpdated)
                    return Result<Unit>.Failure("Error happened while updating todo item");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}