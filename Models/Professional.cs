using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hire_Professionals_Final_Project.Models
{
    //A professinal registered with the system
    public class Professional
    {
        public int Id { get;  set; }

        public string Name { get; set; }

        public string Profession { get; set; }

        public string Mobile { get; set; }

        public string Skills { get; set; }

        public int ExperienceInYears { get; set; }

        public Boolean IsBooked { get; set; }

        public int HourlyRate { get; set; }
    }
}
