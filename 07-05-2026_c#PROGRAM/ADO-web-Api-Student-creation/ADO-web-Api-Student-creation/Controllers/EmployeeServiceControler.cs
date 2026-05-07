using ADO_web_Api_Student_creation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADO_web_Api_Student_creation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeServiceControler : ControllerBase
    {
        private readonly IEmployee _service;
        public EmployeeServiceControler(IEmployee service)
        {
            _service = service;
        }



        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{Employeeid}")]
        public IActionResult GetById(int Employeeid)
        {
            return Ok(_service.GetById(Employeeid) );
        }


        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            _service.AddEmployee(employee);

            return Ok(" Inserted Succesfully");
        }


        [HttpPut("{Employeeid}")]

        public IActionResult Update(Employee employee,int Employeeid)
        {
            _service.UpdateEmployee(employee, Employeeid);
            return Ok(" Updated Record Succesfully");
        }

        [HttpDelete("{Employeeid}")]
        public IActionResult Delete(int Employeeid)
        {
            _service.DeleteEmployee(Employeeid);
            return Ok(" Deletion record Succesfully ");
        }
    }



}
