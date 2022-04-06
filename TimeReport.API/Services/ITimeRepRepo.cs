namespace TimeReport.API.Services
{
    public interface ITimeRepRepo<T>
    {
        public Task<T> GetHoursByWeekAsync(int employee, int week);

    }
}
