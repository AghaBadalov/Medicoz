using Medicoz.DAL;
using Medicoz.Helpers;
using Medicoz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Medicoz.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = ("SuperAdmin,Admin"))]

    public class AppointmentController : Controller
    {
        private readonly AppDbContext _context;

        public AppointmentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            var query = _context.Appointments.Include(x=>x.Doctor).Where(x => x.Status != Enums.Status.Accepted).AsQueryable();
            PaginatedList<Appointment> appointments = PaginatedList<Appointment>.Create(query, 5, page);
            return View(appointments);
        }
        public IActionResult Accepted(int page = 1)
        {
            var query = _context.Appointments.Include(x => x.Doctor).Where(x=>x.Status==Enums.Status.Accepted).AsQueryable();
            PaginatedList<Appointment> appointments = PaginatedList<Appointment>.Create(query, 5, page);
            return View(appointments);
        }
        public IActionResult Reject(int id)
        {
            Appointment appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);
            if (appointment == null) return NotFound();
            appointment.Status = Enums.Status.Declined;
            _context.SaveChanges();
            return RedirectToAction("index");

         }
        public IActionResult Accept(int id)
        {
            Appointment appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);
            if (appointment == null) return NotFound();
            appointment.Status = Enums.Status.Accepted;
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Detail(int id)
        {
            Appointment appointment = _context.Appointments.Include(x=>x.Doctor).FirstOrDefault(x => x.Id == id);
            if (appointment == null) return NotFound();
            
            
            return View(appointment);

        }

    }
}
