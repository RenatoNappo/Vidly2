using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Models;
using Vidly2.DTOs;
using AutoMapper;

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
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }



        // GET /api/customer/{id}
        [HttpGet]
        public CustomerDTO GetCUstomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer,CustomerDTO>(customer);
        }

        
        // POST /api/customers
        [HttpPost]
        public CustomerDTO CreateCustomer(CustomerDTO customerdto)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerToOaDD = Mapper.Map<CustomerDTO,Customer>(customerdto);
            _context.Customers.Add(customerToOaDD);
            _context.SaveChanges();

            customerdto.Id = customerToOaDD.Id;

            return customerdto;
        }


        // PUT api/customers/{id, customer}
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerdto, customerInDb);

            _context.SaveChanges();
        }


        // DELETE api/customers/{id}
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerToDelete = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerToDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();
        }
    }
}
