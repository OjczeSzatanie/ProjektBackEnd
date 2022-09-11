using AutoMapper;

namespace Projekt_Back_End.Profiles
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            CreateMap<Models.Domain.Movie, Models.DTO.Movie>().ReverseMap();
                //.ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id));
        }
    }
}
