using AutoMapper;

namespace Projekt_Back_End.Profiles
{
    public class KeysProfile : Profile
    {
        public KeysProfile()
        {
            CreateMap<Models.Domain.Movie_Key, Models.DTO.Movie_Key>().ReverseMap();
            //.ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id));
        }
    }
}
