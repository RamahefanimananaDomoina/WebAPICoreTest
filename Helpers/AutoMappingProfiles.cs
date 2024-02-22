using AutoMapper;
using ProjectTestDotNet.Model;

namespace ProjectTestDotNet.Helpers
{
    public class AutoMappingProfiles : Profile
    {

        public AutoMappingProfiles()
        {
            CreateMap<Project, ProjectDTO>().ForMember(dest => dest.weather, opt => opt.MapFrom(src => src.temp2))
             .ForMember(dest => dest.date, opt => opt.MapFrom(src => src._date))
             .ForMember(dest => dest.workingHours, opt => opt.MapFrom(src => src.horaires))
             .ForMember(dest => dest.workAt, opt => opt.MapFrom(src => src.travail))
             .ForMember(dest => dest.temperatureMorning, opt => opt.MapFrom(src => src.meteo))
             .ForMember(dest => dest.temperatureAfternoon, opt => opt.MapFrom(src => src.temp1));

            CreateMap<ProjectDTO, Project>().ForMember(dest => dest._date, opt => opt.MapFrom(src => src.date))
            .ForMember(dest => dest.horaires, opt => opt.MapFrom(src => src.workingHours))
            .ForMember(dest => dest.travail, opt => opt.MapFrom(src => src.workAt))
            .ForMember(dest => dest.meteo, opt => opt.MapFrom(src => src.temperatureMorning))
            .ForMember(dest => dest.temp1, opt => opt.MapFrom(src => src.temperatureAfternoon));
        }
    }
}
