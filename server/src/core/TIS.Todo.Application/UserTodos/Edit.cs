using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TIS.Todo.Data;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application.UserTodos
{
    public class Edit
    {
        public class Command : IRequest
        { 
            public TodoItem TodoItem {get; set;}
        }

        public class Handler : IRequestHandler<Command>
        {
             private readonly DataContext _context;
             private readonly IMapper _mapper;


            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                 var item = _context.TodoItems.Find(request.TodoItem.Id);
                
                 _mapper.Map(request.TodoItem, item);

                 await _context.SaveChangesAsync();

                 return Unit.Value;
            }
        }
    }
}