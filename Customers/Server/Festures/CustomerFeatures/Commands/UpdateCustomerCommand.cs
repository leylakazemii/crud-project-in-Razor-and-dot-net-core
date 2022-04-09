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
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BankAccountNumber { get; set; }
        public string Email { get; set; }
        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
        {
            private readonly IDBContext _context;
            public UpdateCustomerCommandHandler(IDBContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                var Customer = _context.Customers.Where(a => a.Id == command.Id).FirstOrDefault();

                if (Customer == null)
                {
                    return default;
                }
                else
                {
                    Customer.Firstname = command.Firstname;
                    Customer.Lastname = command.Lastname;
                    Customer.PhoneNumber = command.PhoneNumber;
                    Customer.DateOfBirth = command.DateOfBirth;
                    Customer.BankAccountNumber = command.BankAccountNumber;
                    Customer.Email = command.Email;
                    await _context.SaveChanges();
                    return Customer.Id;
                }
            }
        }
    }
}
