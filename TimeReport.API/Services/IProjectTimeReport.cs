using TimeReport.Models;

namespace TimeReport.API.Services

{
    public interface IProjectTimeReport<T>
    {
        Task<IEnumerable<T>> GetAllAsync(Pager pager);
        Task<T> GetSingleAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task<IEnumerable<T>> SearchAsync(string query);
    }
}
