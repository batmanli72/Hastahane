using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastahane_Api.Controllers
{
    public class AppointmentController
    {
        private readonly AppDbContext _context;

        public AppointmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add(Appointment a)
        {
            a.Durum = "Bekliyor";
            _context.Appointments.Add(a);
            _context.SaveChanges();
            return Ok(a);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Appointments.ToList());
        }
        private readonly AppDbContext _context;

        public AppointmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add(Appointment a)
        {
            a.Durum = "Bekliyor";
            _context.Appointments.Add(a);
            _context.SaveChanges();
            return Ok(a);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Appointments.ToList());
        }
    }
}
