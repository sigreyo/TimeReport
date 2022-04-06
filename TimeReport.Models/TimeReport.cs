namespace TimeReport.Models
{
    public class TimeReport
    {
        public int Id { get; set; }
        public DateTime CreatedAt => DateTime.Now;
        public int HoursWork { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public Project Project { get; set; }
        public Employee Employee { get; set; }

    }
}
