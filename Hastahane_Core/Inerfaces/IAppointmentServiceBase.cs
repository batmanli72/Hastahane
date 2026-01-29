using Hastahane_Core.DTOs;

namespace Hastahane_Core.Inerfaces
{
    public class IAppointmentServiceBase
    {
        private Task<Hastahane_Domain.Entities.Appointment> CreateAsync(AppointmentCreateDto dto);
    }
}