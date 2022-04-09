using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers.Shared;
using MediatR;
using Customers.Server.Festures.CustomerFeatures.Queries;
using Customers.Server.Festures.CustomerFeatures.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Customers.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        static List<Customer> customers = new List<Customer>
        { };
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await Mediator.Send(new GetAllCustomersQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            return Ok(await Mediator.Send(new GetCustomerByIdQuery { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            return Ok(await Mediator.Send(customer));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Customer customer, int id)
        {

            if (id != customer.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(customer));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            return Ok(await Mediator.Send(new DeleteCustomerByIdCommand { Id = id }));

        }
    }
}
