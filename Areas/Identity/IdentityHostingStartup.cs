using System;
using Hire_Professionals_Final_Project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Hire_Professionals_Final_Project.Areas.Identity.IdentityHostingStartup))]
namespace Hire_Professionals_Final_Project.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Hire_ProfessionalsIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Hire_ProfessionalsIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                     .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<Hire_ProfessionalsIdentityContext>();
            });
        }
    }
}