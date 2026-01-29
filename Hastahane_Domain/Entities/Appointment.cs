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
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }
        public string Durum { get; set; }
    }
}
