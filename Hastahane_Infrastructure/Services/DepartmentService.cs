using Hastahane_Core.DTOs;
using Hastahane_Core.Interfaces;
using Hastahane_Domain.Entities;
using Hastahane_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hastahane_Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _context.Departments.Include(d => d.Doctors).ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            var department = await _context.Departments
                .Include(d => d.Doctors)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (department == null)
                throw new Exception("Department not found");

            return department;
        }

        public async Task<Department> CreateAsync(DepartmentCreateDto dto)
        {
            var department = new Department
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return department;
        }
    }
}