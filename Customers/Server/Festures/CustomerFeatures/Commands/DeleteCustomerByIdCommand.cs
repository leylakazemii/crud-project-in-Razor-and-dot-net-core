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
    public class DeleteCustomerByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, int>
        {
            private readonly IDBContext _context;
            public DeleteCustomerByIdCommandHandler(IDBContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteCustomerByIdCommand command, CancellationToken cancellationToken)
            {
                var Customer = await _context.Customers.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (Customer == null) return default;
                _context.Customers.Remove(Customer);
                await _context.SaveChanges();
                return Customer.Id;
            }
        }
    }
}
