using Microsoft.EntityFrameworkCore;
using TimeReport.API.Models;
using TimeReport.Models;


namespace TimeReport.API.Services
{
    public class EmployeeRepo : IProjectTimeReport<Employee>
    {
        private readonly TimeReportDbContext _timeReportDbContext;

        public EmployeeRepo(TimeReportDbContext timeReportDbContext) => _timeReportDbContext = timeReportDbContext;

        public async Task<Employee> AddAsync(Employee entity)
        {
            var added = await _timeReportDbContext.Employees.AddAsync(entity);
            await _timeReportDbContext.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<Employee> DeleteAsync(int id)
        {
            var del = await _timeReportDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (del != null)
            {
                _timeReportDbContext.Employees.Remove(del);
                await _timeReportDbContext.SaveChangesAsync();
                return del;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync() => 
            await _timeReportDbContext.Employees.OrderBy(n=>n.LastName).ToListAsync();

        public async Task<Employee> GetSingleAsync(int id) => 
            await _timeReportDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);

        public async Task<IEnumerable<Employee>> SearchAsync(string query)
        {
            IQueryable<Employee> emp = _timeReportDbContext.Employees;
            if(!string.IsNullOrEmpty(query))
            {
                emp = emp.Where(e=>e.FirstName.Contains(query) || e.LastName.Contains(query));
            }
            return await emp.ToListAsync();
        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            var upd = await _timeReportDbContext.Employees.FirstOrDefaultAsync(e=>e.Id == entity.Id);
            if (upd != null)
            {
                upd.FirstName = entity.FirstName;
                upd.LastName = entity.LastName;
                upd.Role = entity.Role;
                upd.ProjectId = entity.ProjectId;

                await _timeReportDbContext.SaveChangesAsync();
                return upd;
            }
            return null;
        }
    }
}
