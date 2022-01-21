using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUD.EmployeeData;

namespace RestApiCRUD.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData employeeData;

        //Dependency Injection
        public EmployeesController(IEmployeeData employeeData)
        {
            this.employeeData = employeeData;   
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(employeeData.GetEmployees());
        }
    }
}
