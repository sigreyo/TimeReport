using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeReport.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public string? Description { get; set; }
        public string? Customer { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<TimeRep> TimeReports { get; set; }

    }
}
