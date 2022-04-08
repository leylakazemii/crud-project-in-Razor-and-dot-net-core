using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers.Shared;

namespace Customers.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DBContext _context;
        public CustomerController(DBContext context)
        {
            _context = context;
        }
        static List<Customer> customers = new List<Customer>
        {
            new Customer {Id =1, Firstname = "tohid1",Lastname="fathi1",BankAccountNumber="6037997527428602",PhoneNumber="09148933301"},
            new Customer {Id =2, Firstname = "tohid2",Lastname="fathi2",BankAccountNumber="6037997527428602",PhoneNumber="09148933301"},
             };
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            customers = _context.Customers.ToList();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = _context.Customers.Where(c => c.Id == id).FirstOrDefault();
            if (customer == null)
                return NotFound("not found customer");
            return Ok(customer);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            customer.Id = _context.Customers.Max(m => m.Id + 1);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customers = _context.Customers.ToList();
            return Ok(customers);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Customer customer, int id)
        {
            var dbcustomer = _context.Customers.Where(c => c.Id == id).FirstOrDefault();
            if (dbcustomer == null)
                return NotFound("not found customer");
            _context.Entry(dbcustomer).CurrentValues.SetValues(customer);
            _context.SaveChanges();
            customers = _context.Customers.ToList();
            return Ok(customers);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var dbcustomer = _context.Customers.Where(c => c.Id == id).FirstOrDefault();
            if (dbcustomer == null)
                return NotFound("not found customer");
            _context.Customers.Remove(dbcustomer);
            return Ok(customers);

        }
    }
}
