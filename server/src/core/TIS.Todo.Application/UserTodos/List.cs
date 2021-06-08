using System.Collections.Generic;
using System.Linq;
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
    public class List
    {
        public class Query : IRequest<Result<List<ToDoResponse>>>
        {
            public string UserId { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.UserId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, Result<List<ToDoResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IAsyncRepository<TodoItem> _toDoRepository;

            public Handler(IMapper mapper, IAsyncRepository<TodoItem> toDoRepository)
            {
                _mapper = mapper;
                _toDoRepository = toDoRepository;
            }

            public async Task<Result<List<ToDoResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                // TODO: Adding a predicate to the ListAllAsync.
                var toDosResponse = _mapper.Map<List<ToDoResponse>>(await _toDoRepository.ListAllAsync())
                    .Where(x => x.UserId == request.UserId);
                return Result<List<ToDoResponse>>.Success(toDosResponse.ToList());
            }
        }
    }
}