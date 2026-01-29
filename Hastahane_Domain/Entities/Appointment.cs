using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastahane_Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public bool IsConfirmed { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public User User { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!;
    }
}
