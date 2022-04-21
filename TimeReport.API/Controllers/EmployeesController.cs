using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeReport.API.Services;
using TimeReport.Models;

namespace TimeReport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IProjectTimeReport<Employee> _projectTimeReport;
        public EmployeesController(IProjectTimeReport<Employee> projectTimeReport) =>
            _projectTimeReport = projectTimeReport;

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync([FromQuery] Pager pager)
        {
            try
            {
                return Ok(await _projectTimeReport.GetAllAsync(pager));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
            
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetSingleEmployeeAsync(int id)
        {
            try
            {
                var res = await _projectTimeReport.GetSingleAsync(id);
                return res == null ? NotFound() : Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }

        [HttpGet("{search}")]
        public async Task<IActionResult> EmployeeSearchAsync(string query)
        {
            try
            {
                var search = await _projectTimeReport.SearchAsync(query);
                if (search.Any())
                {
                    return Ok(search);
                }
                return NotFound($"An employee containing [{query}] does not exist.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployeeAsync(Employee newEmp)
        {
            try
            {
                if (newEmp == null)
                {
                    return BadRequest();
                }
                var create = await _projectTimeReport.AddAsync(newEmp);
                return CreatedAtAction(nameof(GetSingleEmployeeAsync), new { create.Id}, create);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");                
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployeeAsync(int id, Employee newEmployee)
        {
            try
            {
                if (id != newEmployee.Id)
                {
                    return BadRequest($"Employee with ID {id} does not exist!");
                }
                var upd = await _projectTimeReport.GetSingleAsync(id);
                if (upd == null)
                {
                    return NotFound($"Employee with ID {id} not found!");
                }
                return await _projectTimeReport.UpdateAsync(newEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }
         [HttpDelete("{id}")]
         public async Task<ActionResult<Employee>> DeleteEmployeeAsync(int id)
        {
            try
            {
                var del = await _projectTimeReport.GetSingleAsync(id);
                if (del == null)
                {
                    return NotFound($"Employee with ID {id} not found!");
                }
                return await _projectTimeReport.DeleteAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }


    }
}
