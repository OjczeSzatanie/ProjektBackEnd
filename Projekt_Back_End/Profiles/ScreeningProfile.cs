using AutoMapper;

namespace Projekt_Back_End.Profiles
{
    public class ScreeningProfile : Profile
    {
        public ScreeningProfile() { 
        CreateMap<Models.Domain.Screening, Models.DTO.Screening>().ReverseMap();
    }
    }
}
