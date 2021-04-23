using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea.Models;
using Tarea.Services;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerSC customers = new CustomerSC();

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            var res = customers.GetAllCustomer();
            return Ok(res);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var res = customers.GetCustomerById(id);
            if(res != null)
                return Ok(res);
            return StatusCode(StatusCodes.Status404NotFound, "No se encontro el cliente con ese id");
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer newCustomer)
        {
            try
            {
                customers.AddCustomer(newCustomer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo agregar el cliente");
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] string name)
        {
            try
            {
                customers.UpdateCustomerContactName(id, name);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el nombre del cliente");
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                customers.DeleteCustomerById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el cliente");
            }
        }
    }
}
