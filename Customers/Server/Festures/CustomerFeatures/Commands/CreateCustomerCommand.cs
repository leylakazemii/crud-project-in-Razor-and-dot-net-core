using Customers.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customers.Server.Festures.CustomerFeatures.Commands
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BankAccountNumber { get; set; }
        public string Email { get; set; }
        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
        {
            private readonly IDBContext _context;
            public CreateCustomerCommandHandler(IDBContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
            {
                var Customer = new Customer();
                Customer.Firstname = command.Firstname;
                Customer.Lastname = command.Lastname;
                Customer.PhoneNumber = command.PhoneNumber;
                Customer.DateOfBirth = command.DateOfBirth;
                Customer.BankAccountNumber = command.BankAccountNumber;
                Customer.Email = command.Email;
                _context.Customers.Add(Customer);
                await _context.SaveChanges();
                return Customer.Id;
            }
        }
    }
}
