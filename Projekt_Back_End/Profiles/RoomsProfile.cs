using AutoMapper;

namespace Projekt_Back_End.Profiles
{
    public class RoomsProfile : Profile
    {
        public RoomsProfile()
        {
            CreateMap<Models.Domain.Screening_Room, Models.DTO.Screening_Room>().ReverseMap();
            //.ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id));
        }
    }
}
