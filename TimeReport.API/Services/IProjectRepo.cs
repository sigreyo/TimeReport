using TimeReport.Models;

namespace TimeReport.API.Services
{
    public interface IProjectRepo<T> : IProjectTimeReport<T>
    {
        public Task<IEnumerable<T>> GetEmployeesByProjectAsync(string projectName);

    }
}
