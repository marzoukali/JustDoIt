using AutoMapper;
using TIS.Todo.Api.DTOs;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TodoItem, TodoItem>();
            CreateMap<TodoItem, ToDoResponse>();
            CreateMap<ToDoResponse, TodoItem>();

            CreateMap<ToDoCreateRequest, TodoItem>();
            CreateMap<TodoItem, ToDoCreateRequest>();

            CreateMap<ToDoEditRequest, TodoItem>();
            CreateMap<TodoItem, ToDoEditRequest>();
        }
    }
}