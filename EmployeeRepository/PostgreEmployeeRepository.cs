using RestApiCRUD.EmployeeRepository;
using RestApiCRUD.Models;

namespace RestApiCRUD.EmployeeRepository
{
    public class PostgreEmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _employeeContext;

        public PostgreEmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        Employee IEmployeeRepository.AddEmployee(Employee employee)
        {   
            //employee.Id = Guid.NewGuid();
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        void IEmployeeRepository.DeleteEmployee(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        Employee IEmployeeRepository.EditEmployee(Employee employee)
        {
            Employee exitingEmployee = _employeeContext.Employees.Find(employee.Id);
            if(exitingEmployee != null)
            {
                exitingEmployee.Name = employee.Name;
                _employeeContext.Employees.Update(exitingEmployee);
                _employeeContext.SaveChanges();
            }

            return employee;

        }

        Employee IEmployeeRepository.GetEmployee(long id)
        {
            Employee employee = _employeeContext.Employees.Find(id);
            return employee;
;        }

        List<Employee> IEmployeeRepository.GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }
    }
}
