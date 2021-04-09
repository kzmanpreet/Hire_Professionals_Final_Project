using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hire_Professionals_Final_Project.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Hire_Professionals_Final_Project.Controllers
{
    //Hiring management controller The hiring record is created by the client 
    //The record can be viewd and deleted by the admin
    public class HiresController : Controller
    {
        private readonly Hire_ProfessionalsDatatContext _context;
        private SignInManager<IdentityUser> SignInManager;
       

        public HiresController(Hire_ProfessionalsDatatContext context,
            SignInManager<IdentityUser> SignInManager
            
            )
        {

            this.SignInManager = SignInManager;
           _context = context;
        }

        // GET: Hires
        [Authorize(Roles = "data_admin")]
        public async Task<IActionResult> Index()
        {
            var hire_ProfessionalsDatatContext = _context.Hire.Include(h => h.Client).Include(h => h.Professional);
            return View(await hire_ProfessionalsDatatContext.ToListAsync());
        }

        // GET: Hires/Details/5
        [Authorize(Roles = "data_admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hire = await _context.Hire
                .Include(h => h.Client)
                .Include(h => h.Professional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hire == null)
            {
                return NotFound();
            }

            return View(hire);
        }

        // GET: Hires/Create
        [Authorize(Roles = "client")]
        public IActionResult Create(int id)
        {
            if (SignInManager.IsSignedIn(User)) {

                var Client = (from client in _context.Client
                              where client.Email.Equals(User.Identity.Name)
                              select client).FirstOrDefault();

                Hire hire = new Hire();
                hire.ClientId = Client.Id;
                hire.ProfessionalId = id;
                hire.HireDate = DateTime.Now;

                var professional = _context.Professional.Find(id);
                professional.IsBooked = true;
                _context.Add(hire);
                _context.SaveChanges();

               

                var hireRecord = _context.Hire
                    .Include(h => h.Professional)
                    .Include(h => h.Client)
                    .FirstOrDefault(h => h.Id == hire.Id);
                return View(hireRecord);
                                  
            
            }

                       
        
         
            return View();
        }


        [Authorize(Roles = "data_admin")]

        // GET: Hires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hire = await _context.Hire
                .Include(h => h.Client)
                .Include(h => h.Professional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hire == null)
            {
                return NotFound();
            }

            return View(hire);
        }

        [Authorize(Roles = "data_admin")]
        // POST: Hires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hire = await _context.Hire.Include(h=>h.Professional).FirstOrDefaultAsync(h=>h.Id==id);
            hire.Professional.IsBooked = false;
            _context.Hire.Remove(hire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

     
    }
}
