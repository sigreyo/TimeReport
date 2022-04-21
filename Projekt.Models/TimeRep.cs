using System.ComponentModel.DataAnnotations;

namespace TimeReport.Models
{
    public class TimeRep
    {
        public int Id { get; set; }

        [Range(1,60)]
        public int Hours { get; set; }

        [Range(1, 53)]
        public int WeekNumber { get; set; }

        //relations
        public int? ProjectId { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public Project? Project { get; set; }
    }
}
