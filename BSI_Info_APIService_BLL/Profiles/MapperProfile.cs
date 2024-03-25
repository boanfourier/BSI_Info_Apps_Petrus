using AutoMapper;
using BSI_Info_APIService_BLL.DTOs;
using BSI_Info_APIService_Domain;

namespace BSI_Info_APIService_BLL.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Role mappings
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleCreateDTO, Role>();

            // Events mappings
            CreateMap<Events, EventsDTO>().ReverseMap();
            CreateMap<EventsCreateDTO, Events>();
            CreateMap<EventsUpdateDTO, Events>();

            // Tasks mappings
            CreateMap<Tasks, TasksDTO>().ReverseMap();
            CreateMap<TasksCreateDTO, Tasks>();
            CreateMap<TasksUpdateDTO, Tasks>();

        }
    }
}
