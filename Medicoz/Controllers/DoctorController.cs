using Medicoz.DAL;
using Medicoz.Models;
using Medicoz.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;

namespace Medicoz.Controllers
{
    public class DoctorController : Controller
    {
        private readonly AppDbContext _context;

        public DoctorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            Doctor doctor = _context.Doctors.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            if (doctor == null) return NotFound();
            AppointmentVm appointment = new AppointmentVm
            {
                Doctor = doctor,
                DoctorId = doctor.Id,
            };
            DateTime start = appointment.Doctor.WorkStartTime;
            DateTime end = appointment.Doctor.WorkEndTime;
            List<int> list = new List<int>();
            List<int> list2 = new List<int>();
            for (int i = 0; i < 24; i++)
            {
                list2.Add(i);
            }
            if (end.Hour > start.Hour)
            {
                List<string> need = new List<string>();
                string itemStr = string.Empty;
                for (int i = start.Hour; i < end.Hour; i++)
                {
                    list.Add(i);
                }
                foreach (var item in list)
                {
                    itemStr = (item.ToString() + ":00") + " - " + ((item + 1).ToString() + ":00");
                    need.Add(itemStr);
                }
                ViewBag.List = need;

            }
            else
            {
                List<string> need = new List<string>();
                string itemStr = string.Empty;
                for (int i = start.Hour-1; i >= end.Hour; i--)
                {
                    list2.Remove(i);
                }
                foreach (var item in list2)
                {
                    itemStr = (item.ToString()+":00")+" - "+((item+1).ToString()+":00");
                    need.Add(itemStr);
                       
                    
                }
                ViewBag.List = need;
            }


            //while (start.AddMinutes(60) <= end)
            //{
            //    list.Add(new SelectListItem() { Text = start.ToString("t") + " - " + start.AddMinutes(60).ToString("t") });
            //    start = start.AddMinutes(60);
            //    //i += 1;
            //}
            //foreach (var item in list)
            //{
            //    ViewBag.List += item.Value;
            //}

            return View(appointment);
        }
        [HttpPost]
        public IActionResult Detail(int id, AppointmentVm appointmentVm)
        {

            Doctor doctor = _context.Doctors.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            if (doctor == null) return NotFound();
            appointmentVm.Doctor = doctor;
            appointmentVm.DoctorId = doctor.Id;
            //if (!ModelState.IsValid) return View();

            int startdate = appointmentVm.StartTime.Hour;
            int starttime = appointmentVm.StartDate.DayOfYear;
            //DateTime start = appointmentVm.Doctor.WorkStartTime;
            //DateTime end = appointmentVm.Doctor.WorkEndTime;
            //List<SelectListItem> list=new List<SelectListItem>();
            //int i = 0;
            //while (start.AddHours(1) <= end)
            //{
            //    list.Add(new SelectListItem() { Text = start.ToString("t") + " - " + start.AddHours(1).ToString("t"), Value = i.ToString() });
            //    start = start.AddHours(1);
            //    i += 1;
            //}

            foreach (var item in _context.Appointments.Where(x => x.DoctorId == doctor.Id).ToList())
            {

            }
            return RedirectToAction("index");

        }
    }
}
