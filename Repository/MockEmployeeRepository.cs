/*using RestApiCRUD.Models;

namespace RestApiCRUD.EmployeeRepository
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
                 {
                     Id = Guid.NewGuid(),
                     Name = "Robert De Niro"
                 },
            new Employee()
                 {
                     Id = Guid.NewGuid(),
                     Name = "Andrei Tarkovsky"
                 }
        };

    public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee EditEmployee(Employee employee)
        {
            Employee existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            return existingEmployee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }
    }
}
*/