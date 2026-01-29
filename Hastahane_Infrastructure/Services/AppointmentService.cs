using Hastahane_Core.DTOs;
using Hastahane_Core.Interfaces;
using Hastahane_Core.Rules;
using Hastahane_Domain.Entities;
using Hastahane_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hastahane_Infrastructure.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                .Include(a => a.User)
                .Include(a => a.Doctor)
                .ThenInclude(d => d.Department)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByUserIdAsync(int userId)
        {
            return await _context.Appointments
                .Where(a => a.UserId == userId)
                .Include(a => a.Doctor)
                .ThenInclude(d => d.Department)
                .ToListAsync();
        }

        public async Task<Appointment> CreateAsync(AppointmentCreateDto dto)
        {
            if (!AppointmentRules.IsValidAppointmentDate(dto.AppointmentDate))
                throw new Exception("Appointment date must be in the future");

            var existingAppointments = await _context.Appointments
                .Where(a => a.DoctorId == dto.DoctorId)
                .ToListAsync();

            if (!AppointmentRules.IsAppointmentAvailable(existingAppointments, dto.AppointmentDate, dto.DoctorId))
                throw new Exception("This time slot is already booked for the selected doctor");

            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null)
                throw new Exception("User not found");

            var doctor = await _context.Doctors.FindAsync(dto.DoctorId);
            if (doctor == null)
                throw new Exception("Doctor not found");

            var appointment = new Appointment
            {
                UserId = dto.UserId,
                DoctorId = dto.DoctorId,
                AppointmentDate = dto.AppointmentDate,
                Notes = dto.Notes
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return appointment;
        }

        public async Task<bool> CancelAsync(int appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            if (appointment == null)
                return false;

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}