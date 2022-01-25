using RestApiCRUD.Models;

namespace RestApiCRUD.Repository
{
    public interface EmployeeRepository
    {
        List<Employee> GetAllEmployees();

        Employee GetEmployee(long id);   

        Employee AddEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
        
        Employee UpdateEmployee(Employee employee); 
    }
}
