using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerEditor.API.Models;
using CustomerEditor.Data.Entity;
using CustomerEditor.Data.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerEditor.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: Customers
        // GET: Customers?includeAll=somebool
        [HttpGet]
        [Route("")]
        public IActionResult Get(bool? includeAll = false)
        {
            try
            {
                IEnumerable<Customer> customers;

                if (includeAll.GetValueOrDefault())
                    customers = customerService.GetAll();
                else
                    customers = customerService.GetActive();

                return Ok(customers);

            }
            catch (Exception ex)
            {
                // log message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: Customers/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCustomer(int id)
        {
            try
            {
                Customer customer = customerService.GetById(id);
                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);

            }
            catch (Exception ex)
            {
                // log message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: Customers/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerModel customer)
        {
            try
            {
                if (id != customer.Id)
                {
                    return BadRequest();
                }
                else if (!customerService.Exists(id))
                {
                    return NotFound();
                }

                customerService.Save(customer.ToEntity());

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                // log message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: Customers
        [HttpPost]
        public IActionResult PostCustomer([FromBody] CustomerModel customer)
        {
            try
            {
                Customer customerEntity = customer.ToEntity();

                customerService.Save(customerEntity);

                return CreatedAtAction(nameof(GetCustomer), new { id = customerEntity.Id }, customerEntity);
            }
            catch (Exception ex)
            {
                // log message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: Customers/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (!customerService.Exists(id))
                {
                    return NotFound();
                }

                customerService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                // log message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
