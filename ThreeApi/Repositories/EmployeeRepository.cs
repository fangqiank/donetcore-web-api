using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

namespace ThreeApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public EmployeeRepository()
        {
            _employees.Add(new Employee
            {
                Id = 1,
                DepartmentId = 1,
                FirstName = "Nick",
                LastName = "Carter",
                Gender = Gender.男
            });

            _employees.Add(new Employee
            {
                Id = 2,
                DepartmentId = 1,
                FirstName = "Michael",
                LastName = "Jackson",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 3,
                DepartmentId = 1,
                FirstName = "Mariah",
                LastName = "Carey",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 5,
                DepartmentId = 2,
                FirstName = "Kate",
                LastName = "Winslet",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 6,
                DepartmentId = 2,
                FirstName = "Rob",
                LastName = "Thomas",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 7,
                DepartmentId = 3,
                FirstName = "Avril",
                LastName = "Lavigne",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 8,
                DepartmentId = 3,
                FirstName = "Katy",
                LastName = "Perry",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 9,
                DepartmentId = 3,
                FirstName = "Michelle",
                LastName = "Monaghan",
                Gender = Gender.女
            });

        }

        public Task<Employee> Add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add((employee));
            return Task.Run(() => employee);
            //return Task.CompletedTask;
        }

        public Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {
            return Task.Run(() => _employees.Where(x => x.DepartmentId == departmentId).AsEnumerable());
        }

        public Task<Employee> GetById(int id)
        {
            return Task.Run(() => _employees.FirstOrDefault(x => x.Id == id));
        }

        public Task<Employee> Fire(int id)
        {
            return Task.Run(() =>
            {
                var employee = _employees.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    employee.Fired = true;
                    return employee;
                }

                return null;
            });
        }
    }
}