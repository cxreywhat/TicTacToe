using AutoMapper;
using Core.Dto.GameDto;
using Core.Dto.UserDto;
using Core.Models;

namespace Core.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Game, CreateGameDto>().ReverseMap();
            CreateMap<Game, UpdateGameDto>().ReverseMap();
            CreateMap<Game, UpdateStatusGame>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserRegisterDto>().ReverseMap();
        }
    }
}
