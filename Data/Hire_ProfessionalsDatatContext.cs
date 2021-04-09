using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hire_Professionals_Final_Project.Models;

namespace Hire_Professionals_Final_Project.Models
{
    //Data connection class map the model and the tables
    public class Hire_ProfessionalsDatatContext : DbContext
    {
        public Hire_ProfessionalsDatatContext (DbContextOptions<Hire_ProfessionalsDatatContext> options)
            : base(options)
        {
        }

        public DbSet<Hire_Professionals_Final_Project.Models.Client> Client { get; set; }

        public DbSet<Hire_Professionals_Final_Project.Models.Hire> Hire { get; set; }

        public DbSet<Hire_Professionals_Final_Project.Models.Professional> Professional { get; set; }
    }
}
