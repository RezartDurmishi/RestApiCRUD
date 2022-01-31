using RestApiCRUD.Models;

namespace RestApiCRUD.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(long id);   

        Employee CreateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
        
        Employee UpdateEmployee(Employee employee, long id); 
    }
}
