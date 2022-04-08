using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Customers.Shared;

namespace Customers.Client.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public event Action OnChange;

        public async Task<List<Customer>> CreateCustomer(Customer customer)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/customer", customer);
            Customers = await result.Content.ReadFromJsonAsync<List<Customer>>();
            OnChange.Invoke();
            return Customers;
        }

        public async Task<List<Customer>> DeleteCustomer(int id)
        {

            var result = await _httpClient.DeleteAsync($"api/customer/{id}");
            Customers = await result.Content.ReadFromJsonAsync<List<Customer>>();
            OnChange.Invoke();
            return Customers;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _httpClient.GetFromJsonAsync<Customer>($"api/customer/{id}");
        }

        public async Task<List<Customer>> GetCustomers()
        {
            Customers = await _httpClient.GetFromJsonAsync<List<Customer>>("api/customer");
            return Customers;
        }

        public async Task<List<Customer>> UpdatedCustomer(Customer customer, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/customer/{id}", customer);
            Customers = await result.Content.ReadFromJsonAsync<List<Customer>>();
            OnChange.Invoke();
            return Customers;
        }
    }
}
