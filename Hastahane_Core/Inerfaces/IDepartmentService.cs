using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hastahane_Core.DTOs;

namespace Hastahane_Core.Inerfaces
{
    public class IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(int id);
        Task<Department> CreateAsync(DepartmentCreateDto dto);
    }
}
