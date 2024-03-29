﻿using Microsoft.AspNetCore.Mvc;
using RestApiCRUD.EmployeeRepository;
using RestApiCRUD.Models;

namespace RestApiCRUD.Controllers
{   
    /**
     * 
     */
    [ApiController]
    public class EmployeeController : ControllerBase
    {   

        private IEmployeeRepository employeeRepository;

        //Dependency Injection
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("api/[controller]/list")]
        public IActionResult GetEmployees()
        {
            return Ok(employeeRepository.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/show/{id}")]
        public IActionResult GetEmployee(long id)
        {
            var employee = employeeRepository.GetEmployee(id);

            if (employee == null)
            {
                return NotFound($"Employee with Id: {id} was not found!");
            }

            return Ok(employee);
        }


        [HttpPost]
        [Route("api/[controller]/create")]
        public IActionResult CreateEmployee(Employee employee)
        {

            employeeRepository.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" +  HttpContext.Request.Host 
                + HttpContext.Request.Path + "/" + employee.Id, employee);
        }


        [HttpDelete]
        [Route("api/[controller]/delete/{id}")]
        public IActionResult DeleteEmployee(long id)
        {
            Employee employee = employeeRepository.GetEmployee(id);

            if(employee == null)
            {
                return NotFound($"Employee with Id: {id} was not found!");  
            }

            employeeRepository.DeleteEmployee(employee);
            return Ok($"Employee with id {id} was deleted!");

        }

        [HttpPut]
        [Route("api/[controller]/update/{id}")]
        public Employee EditEmployee(long id, Employee employee)
        {
            Employee existingEmployee = employeeRepository.GetEmployee(id);

            if (existingEmployee == null)
            {
                return null;
            }

            employee.Id = existingEmployee.Id;
            employeeRepository.EditEmployee(employee);

            return employee;
        }
    }
}
