using Microsoft.AspNetCore.Mvc;
using RestApiCRUD.EmployeeData;
using RestApiCRUD.Models;

namespace RestApiCRUD.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository employeeData;

        //Dependency Injection
        public EmployeeController(IEmployeeRepository employeeData)
        {
            this.employeeData = employeeData;
        }

        [HttpGet]
        [Route("api/[controller]/list")]
        public IActionResult GetEmployees()
        {
            return Ok(employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/show/{id}")]
        public IActionResult GetEmployee(long id)
        {
            var employee = employeeData.GetEmployee(id);

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

            employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" +  HttpContext.Request.Host 
                + HttpContext.Request.Path + "/" + employee.Id, employee);
        }


        [HttpDelete]
        [Route("api/[controller]/delete/{id}")]
        public IActionResult DeleteEmployee(long id)
        {
            Employee employee = employeeData.GetEmployee(id);

            if(employee == null)
            {
                return NotFound($"Employee with Id: {id} was not found!");  
            }

            employeeData.DeleteEmployee(employee);
            return Ok($"Employee with id {id} was deleted!");

        }

        [HttpPut]
        [Route("api/[controller]/update/{id}")]
        public Employee EditEmployee(long id, Employee employee)
        {
            Employee existingEmployee = employeeData.GetEmployee(id);

            if (existingEmployee == null)
            {
                return null;
            }

            employee.Id = existingEmployee.Id;
            employeeData.EditEmployee(employee);

            return employee;
        }
    }
}
