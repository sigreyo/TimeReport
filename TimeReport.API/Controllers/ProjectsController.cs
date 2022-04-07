using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeReport.API.Services;
using TimeReport.Models;

namespace TimeReport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        
        private readonly IProjectRepo<Project> _projectRepo;

        public ProjectsController(IProjectRepo<Project> projectRepo) => _projectRepo = projectRepo;
        

        [HttpGet]
        public async Task<IActionResult> GetAllProjectsAsync()
        {
            try
            {
                return Ok(await _projectRepo.GetAllAsync());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingleProjectAsync(int id)
        {
            try
            {
                var res = await _projectRepo.GetSingleAsync(id);
                return res == null ? NotFound() : Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }

        [HttpGet("{search}")]
        public async Task<IActionResult> ProjectSearchAsync(string project)
        {
            try
            {
                var search = await _projectRepo.SearchAsync(project);
                if (search.Any())
                {
                    return Ok(search);
                }
                return NotFound($"A project containing [{project}] does not exist.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }
        [HttpGet("listemp/{project}")]
        public async Task<IActionResult> ListEmployeesByProjectAsync(string project)
        {
            try
            {
                var search = await _projectRepo.GetEmployeesByProjectAsync(project);
                if (search.Any())
                {
                    return Ok(search);
                }
                return NotFound($"A project containing [{project}] does not exist.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProjectAsync(Project newEmp)
        {
            try
            {
                if (newEmp == null)
                {
                    return BadRequest();
                }
                var create = await _projectRepo.AddAsync(newEmp);
                return CreatedAtAction(nameof(GetSingleProjectAsync), new { create.Id }, create);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProjectAsync(int id, Project newProject)
        {
            try
            {
                if (id != newProject.Id)
                {
                    return BadRequest($"Project with ID {id} does not exist!");
                }
                var upd = await _projectRepo.GetSingleAsync(id);
                if (upd == null)
                {
                    return NotFound($"Project with ID {id} not found!");
                }
                return await _projectRepo.UpdateAsync(newProject);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProjectAsync(int id)
        {
            try
            {
                var del = await _projectRepo.GetSingleAsync(id);
                if (del == null)
                {
                    return NotFound($"Project with ID {id} not found!");
                }
                return await _projectRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }


    }
}
