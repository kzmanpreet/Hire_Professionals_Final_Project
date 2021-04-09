using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hire_Professionals_Final_Project.Models
{
    //Hiring details includes the professionsl and Client
    public class Hire
    {

        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ProfessionalId { get; set; }

        public Professional Professional { get; set; }


        public Client Client { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

    }
}
