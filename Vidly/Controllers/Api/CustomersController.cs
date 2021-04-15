using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        public ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<CustomersDto> GetCustomers()
        {
            var _customers = _context.Customers.ToList().Select(Mapper.Map<Customers, CustomersDto>);
            return _customers;
        }

        //GET /api/customers/{id}
        public IHttpActionResult GetCustomer(int id)
        {
            var _customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (_customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customers, CustomersDto>(_customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomersDto customersDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var _customer = Mapper.Map<CustomersDto, Customers>(customersDto);

            _context.Customers.Add(_customer);
            _context.SaveChanges();

            customersDto.Id = _customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + _customer.Id), customersDto);
        }

        //PUT /api/customers/{id}
        [HttpPut]
        public void UpdateCustomer(int id, CustomersDto customersDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var DbCustomer = _context.Customers.SingleOrDefault(c => c.Id == customersDto.Id);

            if (DbCustomer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var _customer = Mapper.Map<CustomersDto, Customers>(customersDto, DbCustomer);

            _context.SaveChanges();
        }

        //DELETE /api/customers/{id}
        [HttpDelete]
        public void DeleteCustomer(int id)
        {

            var DbCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (DbCustomer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }


            _context.Customers.Remove(DbCustomer);
            _context.SaveChanges();
        }
    }
}