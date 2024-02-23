using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectTestDotNet.Model;
using ProjectTestDotNet.Repository;

namespace ProjectTestDotNet.Controllers
{
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ProjectsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/project/all")]
        public ObjectResult GetProjects()
        {
            try
            {
                var allProjectDtos = new List<ProjectDTO>();
                using (var repos = new Projectrepository())
                {
                    // Retrieve all project
                    var allProjects = repos.project.ToList();
                    foreach (var project in allProjects)
                    {
                        allProjectDtos.Add(_mapper.Map<ProjectDTO>(project));

                    }
                    return StatusCode(200, allProjectDtos);
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }


        [HttpPost]
        [Route("api/project/save")]
        public ObjectResult SaveProject(ProjectDTO model)
        {
            try
            {
                var project = _mapper.Map<Project>(model);
                using (var repo = new Projectrepository())
                {
                    // Retrieve all project
                    repo.project.Add(project);

                    repo.SaveChanges();
                    return StatusCode(200, model);

                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet]
        [Route("api/project/getProjectById/{id}")]
        public ObjectResult GetProjectById(Guid id)
        {
            try
            {
                using (var repos = new Projectrepository())
                {
                    var projectDtoSelected = repos.project.ToList().Where(x => x.uuid == id).FirstOrDefault();
                    if (projectDtoSelected != null)
                    {
                        var mappedProjectDto = _mapper.Map<ProjectDTO>(projectDtoSelected);
                        return StatusCode(200, mappedProjectDto);
                    }
                    else
                    {
                        return StatusCode(404, $"Project with ID {id} not found.");
                    }
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

    }
}
