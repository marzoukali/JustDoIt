using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using TIS.Todo.Api.DTOs;
using TIS.Todo.Application.Interfaces.IRepositories;
using TIS.Todo.Domain.Interfaces.IRepositories;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application.UserTodos
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ToDoCreateRequest TodoItem { get; set; }
            public string UserId { get; set; }
        }

        public class TodoItemCreateValidator : AbstractValidator<ToDoCreateRequest>
        {
            public TodoItemCreateValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.UserId).NotEmpty();
                RuleFor(x => x.TodoItem).SetValidator(new TodoItemCreateValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IAppUserRepository _appUserRepository;
            private readonly IMapper _mapper;
            private readonly IAsyncRepository<TodoItem> _toDoRepository;


            public Handler(IMapper mapper, IAppUserRepository appUserRepository,
                IAsyncRepository<TodoItem> toDoRepository)
            {
                _mapper = mapper;
                _appUserRepository = appUserRepository;
                _toDoRepository = toDoRepository;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _appUserRepository.GetUserById(request.UserId);

                if (user == null)
                    return Result<Unit>.Failure("Couldn't get user info in order to create todo");

                var todoItem = _mapper.Map<TodoItem>(request.TodoItem);
                todoItem.User = user;
                todoItem.UserId = user.Id;
                var now = DateTime.Now;
                todoItem.CreatedAt = now;
                todoItem.LastUpdatedAt = now;

                var isCreated = await _toDoRepository.AddAsync(todoItem) > 0;

                if (!isCreated)
                    return Result<Unit>.Failure("Error happened while creating a new todo item");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}