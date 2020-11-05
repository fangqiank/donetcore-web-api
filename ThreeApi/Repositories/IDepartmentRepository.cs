using System.Collections.Generic;
using System.Threading.Tasks;
using Three.Models;

namespace ThreeApi.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> Add(Department model);
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
    }
}
