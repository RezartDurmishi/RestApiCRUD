﻿using RestApiCRUD.Models;

namespace RestApiCRUD.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(long id);   

        Employee AddEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
        
        Employee EditEmployee(Employee employee); 
    }
}
