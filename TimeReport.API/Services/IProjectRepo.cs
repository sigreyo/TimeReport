using TimeReport.Models;

namespace TimeReport.API.Services
{
    public interface IProjectRepo<T>
    {
        public Task<IEnumerable<T>> GetEmployeesByProjectAsync(string projectName);

    }
}
