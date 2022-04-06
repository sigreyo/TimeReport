using TimeReport.API.Models;
using TimeReport.Models;

namespace TimeReport.API.Services
{
    public class ProjectRepo : IProjectRepo<Project>, IProjectTimeReport<Project>
    {
        private readonly TimeReportDbContext _timeReportDbContext;

        public ProjectRepo(TimeReportDbContext timeReportDbContext) => _timeReportDbContext = timeReportDbContext;

        public Task<Project> AddAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task<Project> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetEmployeesByProjectAsync(string projectName)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetSingleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> SearchAsync(string query)
        {
            throw new NotImplementedException();
        }

        public Task<Project> UpdateAsync(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
