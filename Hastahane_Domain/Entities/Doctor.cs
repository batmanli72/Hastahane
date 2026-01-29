using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastahane_Domain.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Department Department { get; set; } = null!;
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
