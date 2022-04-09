using Customers.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customers.Server.Festures.CustomerFeatures.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
        {
            private readonly IDBContext _context;
            public GetCustomerByIdQueryHandler(IDBContext context)
            {
                _context = context;
            }
            public async Task<Customer> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
            {
                var Customer = _context.Customers.Where(a => a.Id == query.Id).FirstOrDefault();
                if (Customer == null) return null;
                return Customer;
            }
        }
    }
}
