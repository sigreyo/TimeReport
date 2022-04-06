using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeReport.Models
{
    public class TimeRep
    {
        public int Id { get; set; }
        public static DateTime CreatedAt => DateTime.Now;
        public int Hours { get; set; }
        public int WeekNumber { get; set; }
        public int? ProjectId { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
