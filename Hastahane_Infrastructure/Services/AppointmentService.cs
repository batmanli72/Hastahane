
using Hastahane_Core.DTOs;
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
                .AsNoTracking() // Sadece listeleme yapıldığı için performansı artırır
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByUserIdAsync(int userId)
        {
            return await _context.Appointments
                .Where(a => a.UserId == userId)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Department)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Appointment> CreateAsync(AppointmentCreateDto dto)
        {
            // 1. KURAL KONTROLÜ: Tarih geçmişte mi?
            // AppointmentRules statik bir sınıfsaydı doğrudan çağrılmalıydı.
            if (!Hastahane_Core.Rules.AppointmentRules.IsValidAppointmentDate(dto.AppointmentDate))
                throw new Exception("Randevu tarihi gelecekte bir zaman olmalıdır.");

            // 2. PERFORMANS: Tüm listeyi çekmek yerine veritabanında kontrol etme
            // AnyAsync kullanımı belleği yormaz.
            var isConflict = await _context.Appointments
                .AnyAsync(a => a.DoctorId == dto.DoctorId && a.AppointmentDate == dto.AppointmentDate);

            if (isConflict)
                throw new Exception("Seçilen doktor için bu zaman dilimi zaten dolu.");

            // 3. VARLIK KONTROLLERİ
            var userExists = await _context.Users.AnyAsync(u => u.Id == dto.UserId);
            if (!userExists) throw new Exception("Kullanıcı bulunamadı.");

            var doctorExists = await _context.Doctors.AnyAsync(d => d.Id == dto.DoctorId);
            if (!doctorExists) throw new Exception("Doktor bulunamadı.");

            // 4. ATAMA VE KAYIT
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