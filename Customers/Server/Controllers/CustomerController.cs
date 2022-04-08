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
        static List<Customer> customers = new List<Customer>
        {
            new Customer {Id =1, Firstname = "tohid1",Lastname="fathi1",BankAccountNumber="6037997527428602",PhoneNumber="09148933301"},
            new Customer {Id =2, Firstname = "tohid2",Lastname="fathi2",BankAccountNumber="6037997527428602",PhoneNumber="09148933301"},
             };
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = customers.Where(c => c.Id == id).FirstOrDefault();
            if (customer == null)
                return NotFound("not found customer");
            return Ok(customer);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            customer.Id = customers.Max(m => m.Id + 1);
            customers.Add(customer);
            return Ok(customers);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Customer customer, int id)
        {
            var dbcustomer = customers.Where(c => c.Id == id).FirstOrDefault();
            if (dbcustomer == null)
                return NotFound("not found customer");
            var index = customers.IndexOf(dbcustomer);
            customers[index] = customer;
            return Ok(customers);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer( int id)
        {
            var dbcustomer = customers.Where(c => c.Id == id).FirstOrDefault();
            if (dbcustomer == null)
                return NotFound("not found customer");
            customers.Remove(dbcustomer);
            return Ok(customers);

        }
    }
}
