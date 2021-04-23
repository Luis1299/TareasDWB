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
    public class ProductController : ControllerBase
    {

        private ProductSC productsService = new ProductSC();

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            var products = productsService.GetAllProducts().ToList();
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = productsService.GetProductById(id);
            if(product != null)
                return Ok(product);
            return StatusCode(StatusCodes.Status404NotFound, "El producto con esa id no existe");
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product newProduct)
        {
            try
            {
                productsService.AddProduct(newProduct);
                return Ok();
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo agregar el producto");
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string name)
        {
            try
            {
                productsService.UpdateProductName(id, name);
                return Ok();
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el nombre");
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                productsService.DeleteProductById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo borrar ese producto");
            }
        }
    }
}
