using System.Linq;
using AutoMapper;
using DatingApplication.Dtos;
using DatingApplication.Models;

namespace DatingApplication.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Users, UserForDetailsDto>()
                .ForMember(d => d.PhotoUrl, o=>
                    o.MapFrom(src => src.Photos.FirstOrDefault(p=>p.IsMain).Url))
                 .ForMember(d=>d.Age, o => 
                    o.MapFrom(src => src.DateOfBirth.CalculteAge()));
            CreateMap<Users, UserFroListDto>()
                .ForMember(d => d.PhotoUrl, o=>
                    o.MapFrom(src => src.Photos.FirstOrDefault(p=>p.IsMain).Url))
                 .ForMember(d=>d.Age, o => 
                    o.MapFrom(src => src.DateOfBirth.CalculteAge()));
            CreateMap<Photos, PhotoForDetailsDto>();
        }
    }
}