using RestApiCRUD.Models;

namespace RestApiCRUD.Repository
{
    public class EmployeeService : EmployeeRepository
    {
        private EmployeeContext _employeeContext;

        public EmployeeService(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        /**
         * List all employees
         */
        List<Employee> EmployeeRepository.GetAllEmployees()
        {
            return _employeeContext.Employees.ToList();
        }

        /**
         * Get single employee
         */
        Employee EmployeeRepository.GetEmployee(long id)
        {
            return _employeeContext.Employees.Find(id);
        }

        /**
         * Add new employee
         */
        Employee EmployeeRepository.AddEmployee(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        /**
         * Delete employee
         */
        void EmployeeRepository.DeleteEmployee(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        /**
         * Update employee
         */
        Employee EmployeeRepository.UpdateEmployee(Employee employee)
        {
            Employee exitingEmployee = _employeeContext.Employees.Find(employee.Id);
            if (exitingEmployee != null)
            {
                exitingEmployee.Name = employee.Name;
                _employeeContext.Employees.Update(exitingEmployee);
                _employeeContext.SaveChanges();
            }

            return employee;
        }

    }
}
