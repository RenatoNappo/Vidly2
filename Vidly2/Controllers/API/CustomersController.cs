using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Models;
using Vidly2.DTOs;
using AutoMapper;
using System.Data.Entity;
using System.Data.Entity.Validation;


namespace Vidly2.Controllers.API
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;


        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        // GET /api/customers
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);

            return Ok(customerDtos);
        }


        // GET /api/customer/{id}
        [HttpGet]
        public IHttpActionResult GetCUstomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }


        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The data you have posted is invalid.");
            }
            var customerToOaDD = Mapper.Map<CustomerDTO, Customer>(customerdto);
            _context.Customers.Add(customerToOaDD);
            _context.SaveChanges();

            customerdto.Id = customerToOaDD.Id;

            return Created(new Uri(Request.RequestUri + "/" + customerToOaDD.Id), customerToOaDD);
        }



        // PUT api/customers/{id, customer}
        [HttpPut]
        [Route("api/customers/UpdateCustomer/{id}")]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest("The data you have posted is invalid.");

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerdto, customerInDb);

            try
            {
                _context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return Ok(customerdto);
        }



        // DELETE api/customers/{id}
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerToDelete = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerToDelete == null)
                return NotFound();

            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();
            return Ok();
        }
    }
}
