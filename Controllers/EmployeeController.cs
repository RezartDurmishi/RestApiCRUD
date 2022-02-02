using Microsoft.AspNetCore.Mvc;
using RestApiCRUD.EmployeeRepository;
using RestApiCRUD.Models;

namespace RestApiCRUD.Controllers
{
    /**
     * Employee Controller
     */
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /**
         * IEmployeeRepository instance
         */
        private IEmployeeRepository employeeRepository;

        /**
         * Dependency Injection
         */
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        /**
         * List employees
         */
        [HttpGet]
        [Route("api/[controller]/list")]
        public IActionResult GetEmployees()
        {
            return Ok(employeeRepository.GetEmployees());
        }

        /**
         * Show employee
         */
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

        /**
         * Create employee
         */
        [HttpPost]
        [Route("api/[controller]/create")]
        public IActionResult CreateEmployee(Employee employee)
        {

            employeeRepository.CreateEmployee(employee);
            return Ok(employee);
        }

        /**
         * Delete employee
         */
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

        /**
         * Update employee
         */
        [HttpPut]
        [Route("api/[controller]/update/{id}")]
        public IActionResult EditEmployee(long id, Employee employee)
        {
            Employee existingEmployee = employeeRepository.GetEmployee(id);

            if (existingEmployee == null)
            {
                return NotFound($"Employee with id {id} is not found");
            }

            try
            {
                existingEmployee = employeeRepository.UpdateEmployee(employee, id);
                return Ok(existingEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
