using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;
using ThreeApi.Repositories;

namespace ThreeApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("{departmentId}")]
        public async Task<ActionResult> GetByDepartmentId(int departmentId)
        {
            var employees = await _employeeRepository.GetByDepartmentId(departmentId);

            if (!employees.Any())
            {
                return NoContent();
            }

            return Ok(employees);
        }

        [HttpGet("One/{id}",Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _employeeRepository.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Fire(int id)
        {
            var result = await _employeeRepository.Fire(id);

            if (result != null)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Employee employee)
        {
            var added = await _employeeRepository.Add(employee);
            return CreatedAtRoute("GetById", new {id = added.Id}, added);
        }
    }
}
