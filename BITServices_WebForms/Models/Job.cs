using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices_WebForms.Models
{
    class Job
    {
        public DateTime StartDateTime { get; set; }
        public Client JobClient { get; set; }
        public DateTime EndDateTime { get; set; }
        public Contractor AssignedContractor { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public double DistanceTravelled { get; set; }
        public string Urgency { get; set; }
        public Employee AssignedEmployee { get; set; }
        public string SkillType { get; set; }
        public string JobDetails { get; set; }
    }
}
