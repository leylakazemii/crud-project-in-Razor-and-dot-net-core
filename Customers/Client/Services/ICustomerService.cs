using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers.Shared;

namespace Customers.Client.Services
{
    public interface ICustomerService
    {
        event Action OnChange;
        List<Customer> Customers { get; set; }
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int id);
        Task<List<Customer>> CreateCustomer(Customer customer);
        Task<List<Customer>> UpdatedCustomer(Customer customer,int id);
        Task<List<Customer>> DeleteCustomer(int id);
    }
}
