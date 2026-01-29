using Hastahane_Core.DTOs;
using Hastahane_Domain.Entities;

namespace Hastahane_Core.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(int id);
        Task<Department> CreateAsync(DepartmentCreateDto dto);
    }
}