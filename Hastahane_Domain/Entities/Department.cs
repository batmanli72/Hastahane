using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastahane_Domain.Entities
{
    public class Department
    {
        private ICollection<Doctor> doctors = [];

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<Doctor> Doctors { get => doctors; set => doctors = value; }
    }
}
