using RestApiCRUD.Models;

namespace RestApiCRUD.EmployeeData
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(Guid id);   

        Employee AddEmployee(Employee employee);

        void DeleteEmployee(Guid id);
        
        void UpdateEmployee(Employee employee); 
    }
}
