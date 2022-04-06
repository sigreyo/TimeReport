using TimeReport.API.Models;
using TimeReport.Models;
using Microsoft.EntityFrameworkCore;


namespace TimeReport.API.Services
{
    public class ProjectRepo : IProjectRepo<Project>, IProjectTimeReport<Project>
    {
        private readonly TimeReportDbContext _timeReportDbContext;

        public ProjectRepo(TimeReportDbContext timeReportDbContext) => _timeReportDbContext = timeReportDbContext;

        public async Task<Project> AddAsync(Project entity)
        {
            var added = await _timeReportDbContext.Projects.AddAsync(entity);
            await _timeReportDbContext.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<Project> DeleteAsync(int id)
        {
            var del = await _timeReportDbContext.Projects.FirstOrDefaultAsync(e => e.Id == id);
            if (del != null)
            {
                _timeReportDbContext.Projects.Remove(del);
                await _timeReportDbContext.SaveChangesAsync();
                return del;
            }
            return null;
        }

        public async Task<IEnumerable<Project>> GetAllAsync() => 
            await _timeReportDbContext.Projects.ToListAsync();
       

        public async Task<IEnumerable<Project>> GetEmployeesByProjectAsync(string projectName)
        {
            return await _timeReportDbContext.Projects.Include(e => e.Employees).Where
                (p => p.Name == projectName).ToListAsync();
                
        }

        public async Task<Project> GetSingleAsync(int id) => 
            await _timeReportDbContext.Projects.FirstOrDefaultAsync(p=>p.Id == id);
        

        public async Task<IEnumerable<Project>> SearchAsync(string query)
        {
            IQueryable<Project> proj = _timeReportDbContext.Projects;
            if (!string.IsNullOrEmpty(query))
            {
                proj = proj.Where(p => p.Name.Contains(query));
            }
            return await proj.ToListAsync();
        }

        public async Task<Project> UpdateAsync(Project entity)
        {
            var upd = await _timeReportDbContext.Projects.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (upd != null)
            {
                upd.Name = entity.Name;
                upd.StartedAt = entity.StartedAt;
                upd.EndedAt = entity.EndedAt;
                upd.Description = entity.Description;
                upd.Customer = entity.Customer;

                await _timeReportDbContext.SaveChangesAsync();
                return upd;
            }
            return null;
        }
    }
}
