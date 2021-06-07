using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using TIS.Todo.Data;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application.UserTodos
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public TodoItem TodoItem { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.TodoItem).SetValidator(new TodoItemValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;


            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var item = _context.TodoItems.Find(request.TodoItem.Id);

                if (item == null) return null;

                _mapper.Map(request.TodoItem, item);

                var isUpdated = await _context.SaveChangesAsync() > 0;


                if (!isUpdated)
                    return Result<Unit>.Failure("Error happened while updating todo item");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}