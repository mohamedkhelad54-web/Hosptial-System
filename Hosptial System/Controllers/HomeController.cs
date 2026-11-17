using Hosptial_System.Data;
using Hosptial_System.Data;
using Hosptial_System.Models;
using Hosptial_System.Models;
using Hosptial_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics;

namespace Hosptial_System.Controllers
{

    public class HomeController : Controller
    {
        private readonly Hospatialdbcontext context = new Hospatialdbcontext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Doctor(doctorVM d1)
        {
            var Doctor = context.doctors.AsQueryable();
            if(d1.name!=null)
            {
                Doctor = Doctor.Where(p => p.Name.Contains(d1.name));
            }
            if(d1.specialzation!=null)
            {
                Doctor = Doctor.Where(p => p.Specialization.Contains(d1.specialzation));
            }
            Doctor = Doctor.Skip((d1.page-1)*8).Take(4);
            ViewBag.total_page = (int)Math.Ceiling(Doctor.Count()/4.0);
            ViewBag.current_page=d1.page;
            return View(Doctor.ToList());
        }
       

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Doctors = new SelectList(context.doctors.ToList(), "Id", "Name");
            ViewBag.Specializations = new SelectList(
                context.doctors.Select(d => d.Specialization).Distinct().ToList()
            );
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appontimant appontimant, string patientName)
        {
            if (!string.IsNullOrWhiteSpace(patientName))
            {
                var patient = new Patient { name = patientName };
                context.patients.Add(patient);
                context.SaveChanges();

                appontimant.PatientId = patient.Id;
            }

            context.appontimants.Add(appontimant);
            context.SaveChanges();

            return RedirectToAction(nameof(page_appontiment));
        }
        public  IActionResult appontiment()
        {           
            return View();
        }

        public IActionResult page_appontiment()
        {
            var Appointment = context.appontimants.AsQueryable();

            Appointment = Appointment
                .Include(p => p.Doctor)
                .Include(p => p.Patient);

            return View(Appointment.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}