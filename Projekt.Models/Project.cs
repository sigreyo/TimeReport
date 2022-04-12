using System.ComponentModel.DataAnnotations;

namespace TimeReport.Models
{
    public class Project
    {
        public int Id { get; set; }

        [MinLength(1), MaxLength(20)]
        public string Name { get; set; }

        [Range(typeof(DateTime), "2015-01-01T00:00:00", "2017-06-06T00:00:00")]
        public DateTime StartedAt { get; set; }

        [Range(typeof(DateTime), "2015-01-01T00:00:00", "2017-06-06T00:00:00")]
        public DateTime? EndedAt { get; set; }

        [MaxLength(150)]
        public string? Description { get; set; }

        [MinLength(1), MaxLength(30)]
        public string? Customer { get; set; }

        //relations
        public ICollection<Employee> Employees { get; set; }
        public ICollection<TimeRep> TimeReports { get; set; }

    }
}
