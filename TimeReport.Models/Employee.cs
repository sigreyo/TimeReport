namespace TimeReport.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProjectId { get; set; }
        public int TimeReportId { get; set; }
        public Project Project { get; set; }
        public ICollection<TimeReport> TimeReports { get; set; }
    }
}