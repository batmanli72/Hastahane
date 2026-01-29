using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastahane_Core.Inerfaces
{
    public class IAppointmentService
    {
        void Add(Appointment appointment);
        List<Appointment> GetByUser(int userId);
        List<Appointment> GetAll(); void Add(Appointment appointment);
        List<Appointment> GetByUser(int userId);
        List<Appointment> GetAll();
    }
}
