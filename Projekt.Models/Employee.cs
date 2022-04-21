using System.ComponentModel.DataAnnotations;


namespace TimeReport.Models
{
    public class Employee
    {
        
        public int Id { get; set; }

        [MinLength(1), MaxLength(20)]       
        public string FirstName { get; set; }

        [MinLength(1), MaxLength(20)]
        public string LastName { get; set; }

        [MinLength(1), MaxLength(25)]
        public string Role { get; set; }

        //relations
        public int ProjectId { get; set; }
        public ICollection<TimeRep>? TimeReports { get; set; }
        public Project? Project { get; set; }

    }
}