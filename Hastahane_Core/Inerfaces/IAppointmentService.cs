using Hastahane_Core.DTOs;
using Hastahane_Domain.Entities;

namespace Hastahane_Core.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<IEnumerable<Appointment>> GetByUserIdAsync(int userId);
        Task<Appointment> CreateAsync(AppointmentCreateDto dto);
        Task<bool> CancelAsync(int appointmentId);
    }
}