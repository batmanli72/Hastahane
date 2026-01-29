using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hastahane_Core.DTOs;

namespace Hastahane_Core.Inerfaces
{
    public class IDocctorService
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<IEnumerable<Doctor>> GetByDepartmentAsync(int departmentId);
        Task<Doctor> GetByIdAsync(int id);
        Task<Doctor> CreateAsync(DoctorCreateDto dto);
    }
}
