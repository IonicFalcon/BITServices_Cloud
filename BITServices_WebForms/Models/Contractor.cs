using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices_WebForms.Models
{
    class Contractor : Person
    {
        public int ContractorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<String> SkillList { get; set; }
        public DataTable Roster { get; set; }
        public int Rating { get; set; }

    }
}
