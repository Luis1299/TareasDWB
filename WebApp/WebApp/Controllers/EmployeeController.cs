using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea.Models;
using Tarea.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private EmployeeSC employees = new EmployeeSC();

        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get()
        {
            var employeesList = employees.GetAllEmployees().ToList();
            return Ok(employeesList);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = employees.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return StatusCode(StatusCodes.Status404NotFound, "El empleado con esa id no existe");
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee newEmployee)
        {
            try
            {
                employees.AddEmployee(newEmployee);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrio un error al registrar el empleado");
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string firstName)
        {
            try
            {
                employees.UpdateEmployeeFirstNameById(id, firstName);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try {
                employees.DeleteEmployeeById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
    }
}
