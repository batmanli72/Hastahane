using Hastahane_Core.DTOs;
using Hastahane_Core.Interfaces;
using Hastahane_Domain.Entities;
using Hastahane_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hastahane_Infrastructure.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDbContext _context;

        public DoctorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.Include(d => d.Department).ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetByDepartmentAsync(int departmentId)
        {
            return await _context.Doctors
                .Where(d => d.DepartmentId == departmentId)
                .Include(d => d.Department)
                .ToListAsync();
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            var doctor = await _context.Doctors
                .Include(d => d.Department)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (doctor == null)
                throw new Exception("Doctor not found");

            return doctor;
        }

        public async Task<Doctor> CreateAsync(DoctorCreateDto dto)
        {
            var department = await _context.Departments.FindAsync(dto.DepartmentId);
            if (department == null)
                throw new Exception("Department not found");

            var doctor = new Doctor
            {
                FullName = dto.FullName,
                Specialty = dto.Specialty,
                DepartmentId = dto.DepartmentId
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }
    }
}