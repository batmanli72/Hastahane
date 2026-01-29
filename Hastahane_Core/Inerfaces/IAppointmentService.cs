using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hastahane_Core.DTOs;

namespace Hastahane_Core.Inerfaces
{
    public class IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<IEnumerable<Appointment>> GetByUserIdAsync(int userId);
        Task<Appointment> CreateAsync(AppointmentCreateDto dto);
        Task<bool> CancelAsync(int appointmentId);
    }
}
