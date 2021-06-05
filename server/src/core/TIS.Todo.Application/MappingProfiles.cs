using AutoMapper;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TodoItem, TodoItem>();
        }
    }
}