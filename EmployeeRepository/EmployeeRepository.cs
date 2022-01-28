using RestApiCRUD.EmployeeRepository;
using RestApiCRUD.Models;

namespace RestApiCRUD.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _employeeContext;

        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        
        /**
         * List employees
         */
        List<Employee> IEmployeeRepository.GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }

        /**
         * Get employee by id
         */
        Employee IEmployeeRepository.GetEmployee(long id)
        {
            return _employeeContext.Employees.Find(id);
        }
        
        /**
         * Add employee
         */
        Employee IEmployeeRepository.CreateEmployee(Employee employee)
        {   
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        /**
         * Delete employee
         */
        void IEmployeeRepository.DeleteEmployee(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        /**
         * Update employee
         */
        Employee IEmployeeRepository.UpdateEmployee(Employee employee, long id)
        {
            employee.Id = id;
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }
    }
}
