using AutoMapper;
using Chat.Room.Domain.DTO;
using Chat.Room.Domain.Model;

namespace Chat.Room.Application.Mapping
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<LoginDTO, Login>()
                .ForMember(x => x.Id, p => p.MapFrom(d => d.id))
                .ForMember(x => x.Username, p => p.MapFrom(d => d.username))
                .ForMember(x => x.Password, p => p.MapFrom(d => d.password))
                .ReverseMap();
        }
    }
}
