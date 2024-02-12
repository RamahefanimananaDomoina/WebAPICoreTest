using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectTestDotNet.Model;
using ProjectTestDotNet.Repository;

namespace ProjectTestDotNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        [Route("api/getProject")]
        public ObjectResult GetProjects()
        {
            try
            {
                // Extracted mapping configuration
                var mapper = CreateMapper();

                var dtos = new List<ProjectDTO>();
                using (var context = new Projectrepository())
                {
                    // Retrieve all project
                    var allEmployees = context.project.ToList();
                    foreach (var employee in allEmployees)
                    {
                        dtos.Add(mapper.Map<ProjectDTO>(employee));

                    }
                    return StatusCode(200, dtos);
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }


        [HttpPost]
        [Route("api/saveProject")]
        public ObjectResult SaveProject(ProjectDTO model)
        {
            try
            {
                // Extracted mapping configuration
                var mapper  = CreateMapper();
                var project = mapper.Map<Project>(model);
                using (var context = new Projectrepository())
                {
                    // Retrieve all employees
                    var allEmployees = context.project.Add(project);

                    context.SaveChanges();
                    return StatusCode(200, model);

                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => {
                // DTO to Domain Model
                cfg.CreateMap<Project, ProjectDTO>().ForMember(dest => dest.weather, opt => opt.MapFrom(src => src.temp2))
                    .ForMember(dest => dest.date, opt => opt.MapFrom(src => src._date))
                    .ForMember(dest => dest.workingHours, opt => opt.MapFrom(src => src.horaires))
                    .ForMember(dest => dest.workAt, opt => opt.MapFrom(src => src.travail))
                    .ForMember(dest => dest.temperatureMorning, opt => opt.MapFrom(src => src.meteo))
                    .ForMember(dest => dest.temperatureAfternoon, opt => opt.MapFrom(src => src.temp1));

                // Domain Model to DTO
                cfg.CreateMap<ProjectDTO, Project>().ForMember(dest => dest._date, opt => opt.MapFrom(src => src.date))
                    .ForMember(dest => dest.horaires, opt => opt.MapFrom(src => src.workingHours))
                    .ForMember(dest => dest.travail, opt => opt.MapFrom(src => src.workAt))
                    .ForMember(dest => dest.meteo, opt => opt.MapFrom(src => src.temperatureMorning))
                    .ForMember(dest => dest.temp1, opt => opt.MapFrom(src => src.temperatureAfternoon)); 
            });

            return new Mapper(config);
        }

    }
}
