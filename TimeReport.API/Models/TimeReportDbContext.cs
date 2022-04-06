using Microsoft.EntityFrameworkCore;
using TimeReport.Models;

namespace TimeReport.API.Models
{
    public class TimeReportDbContext : DbContext
    {
        public DbSet<TimeRep> TimeReports { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

        public TimeReportDbContext(DbContextOptions<TimeReportDbContext> options) : base(options)
        {
        }
    }
}
