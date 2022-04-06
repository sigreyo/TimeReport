namespace TimeReport.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int EmployeeId { get; set; }
        public int TimeReportId { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<TimeReport> TimeReports { get; set; }
    }
}
