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
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
        {
            private readonly IDBContext _context;
            public GetAllCustomersQueryHandler(IDBContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
            {
                var CustomerList = await _context.Customers.ToListAsync();
                if (CustomerList == null)
                {
                    return null;
                }
                return CustomerList.AsReadOnly();
            }
        }
    }
}
