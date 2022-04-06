using Microsoft.EntityFrameworkCore;
using TimeReport.API.Models;
using TimeReport.Models;

namespace TimeReport.API.Services
{
    public class TimeRepRepo : ITimeRepRepo<TimeRep>, IProjectTimeReport<TimeRep>
    {
        private readonly TimeReportDbContext _timeReportDbContext;

        public TimeRepRepo(TimeReportDbContext timeReportDbContext) => _timeReportDbContext = timeReportDbContext;

        public async Task<TimeRep> AddAsync(TimeRep entity)
        {
            var added = await _timeReportDbContext.TimeReports.AddAsync(entity);
            await _timeReportDbContext.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<TimeRep> DeleteAsync(int id)
        {
            var del = await _timeReportDbContext.TimeReports.FirstOrDefaultAsync(e => e.Id == id);
            if (del != null)
            {
                _timeReportDbContext.TimeReports.Remove(del);
                await _timeReportDbContext.SaveChangesAsync();
                return del;
            }
            return null;
        }

        public async Task<IEnumerable<TimeRep>> GetAllAsync() => 
            await _timeReportDbContext.TimeReports.ToListAsync();

        public async Task<TimeRep> GetHoursByWeekAsync(int employee, int week)
        {
            //IQueryable<TimeRep> rep = _timeReportDbContext.TimeReports;
            //rep = rep.Where(t => t.EmployeeId == employee && t.WeekNumber == week);
            //return await rep.FirstOrDefaultAsync();            
            return await _timeReportDbContext.TimeReports.Where
                (t => t.EmployeeId == employee && t.WeekNumber == week).FirstOrDefaultAsync();
        }

        public async Task<TimeRep> GetSingleAsync(int id) => 
            await _timeReportDbContext.TimeReports.FirstOrDefaultAsync(t => t.Id == id);

        public Task<IEnumerable<TimeRep>> SearchAsync(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<TimeRep> UpdateAsync(TimeRep entity)
        {
            var upd = await _timeReportDbContext.TimeReports.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (upd != null)
            {
                upd.Hours = entity.Hours;
                upd.WeekNumber = entity.WeekNumber;
                upd.ProjectId = entity.ProjectId;
                upd.EmployeeId = entity.EmployeeId;

                await _timeReportDbContext.SaveChangesAsync();
                return upd;
            }
            return null;
        }
    }
}
