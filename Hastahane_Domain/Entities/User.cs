using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastahane_Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Rol { get; set; }
    }
}
