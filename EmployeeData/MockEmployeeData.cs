using RestApiCRUD.Models;

namespace RestApiCRUD.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
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
            throw new NotImplementedException();
        }

        public void DeleteEmployee(Guid id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
