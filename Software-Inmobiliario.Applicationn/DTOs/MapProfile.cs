using AutoMapper;
using Software_Inmobiliario.Applicationn.Authentication;
using Software_Inmobiliario.Domain.Entities;

namespace Software_Inmobiliario.Applicationn;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<User, AuthResponseDto>();
        CreateMap<AuthResponseDto, User>();
    }
}