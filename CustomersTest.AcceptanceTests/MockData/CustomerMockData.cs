using Customers.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersTest.AcceptanceTests.MockData
{
    public class CustomerMockData
    {
        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
        {
            new Customer {Id =1, Firstname = "tohid1",Lastname="fathi1",BankAccountNumber="6037997527428602",PhoneNumber="09148933301",Email="k_odi1@yahoo.com"},
            new Customer {Id =2, Firstname = "tohid2",Lastname="fathi2",BankAccountNumber="6037997527428602",PhoneNumber="09148933301",Email="k_odi2@yahoo.com"},
            new Customer {Id =3, Firstname = "tohid3",Lastname="fathi3",BankAccountNumber="6037997527428602",PhoneNumber="09148933301",Email="k_odi3@yahoo.com"},
             };

        }
    }
}
