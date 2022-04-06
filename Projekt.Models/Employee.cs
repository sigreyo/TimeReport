﻿namespace TimeReport.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int ProjectId { get; set; }
        public ICollection<TimeRep> TimeReports { get; set; }
        public Project Project { get; set; }

    }
}