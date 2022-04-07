using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeReport.API.Services;
using TimeReport.Models;

namespace TimeReport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportsController : ControllerBase
    {
        private readonly ITimeRepRepo<TimeRep> _timeRepRepo;

        public TimeReportsController(ITimeRepRepo<TimeRep> timeRepRepo) => _timeRepRepo = timeRepRepo;

        [HttpGet]
        public async Task<IActionResult> GetAllTimeReportsAsync([FromQuery] Pager pager)
        {
            try
            {
                return Ok(await _timeRepRepo.GetAllAsync(pager));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingleTimeReportAsync(int id)
        {
            try
            {
                var res = await _timeRepRepo.GetSingleAsync(id);
                return res == null ? NotFound() : Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }
        [HttpGet("{employee}/{week}")]
        public async Task<IActionResult> GetHoursByWeekAsync(int employee, int week)
        {
            try
            {
                var res = await _timeRepRepo.GetHoursByWeekAsync(employee, week);
                return res == null ? NotFound() : Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddTimeReportAsync(TimeRep timeRep)
        {
            try
            {
                if (timeRep == null)
                {
                    return BadRequest();
                }
                var create = await _timeRepRepo.AddAsync(timeRep);
                return CreatedAtAction(nameof(GetSingleTimeReportAsync), new { create.Id }, create);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TimeRep>> UpdateTimeReportAsync(int id, TimeRep newTimeReport)
        {
            try
            {
                if (id != newTimeReport.Id)
                {
                    return BadRequest($"TimeReport with ID {id} does not exist!");
                }
                var upd = await _timeRepRepo.GetSingleAsync(id);
                if (upd == null)
                {
                    return NotFound($"TimeReport with ID {id} not found!");
                }
                return await _timeRepRepo.UpdateAsync(newTimeReport);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeRep>> DeleteTimeReportAsync(int id)
        {
            try
            {
                var del = await _timeRepRepo.GetSingleAsync(id);
                if (del == null)
                {
                    return NotFound($"TimeReport with ID {id} not found!");
                }
                return await _timeRepRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }
        }


    }
}
