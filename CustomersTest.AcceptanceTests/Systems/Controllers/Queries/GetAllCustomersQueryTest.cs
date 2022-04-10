using AutoMapper;
using CustomersTest.AcceptanceTests.MockData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customers.Server.Festures.CustomerFeatures.Queries;


namespace CustomersTest.AcceptanceTests.Systems.Controllers.Queries
{
   public  class GetAllCustomersQueryTest
    {
        private readonly Mock<CustomerMockData> _mockRepo;
        //public async Task GetAllCustomersQueryTest()
        //{
        //    var query= new GetAllCustomersQuery();

        //    var result = await SendAsync(query);

        //    result.PriorityLevels.Should().NotBeEmpty();
        //}
    }
}
