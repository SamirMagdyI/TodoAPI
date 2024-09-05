using AutoMapper;
using TodoAPI.Dtos;
using TodoAPI.Models;

namespace TodoAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoDto, Todo>()
          .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Todo, TodoDto>();
        }
    }
}
