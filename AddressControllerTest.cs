using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using petrgAPI.Models;
using Shouldly;

using System.Net;
using System.Net.Http.Json;

namespace PetRGTest
{
    public class AddressControllerTest : IntegrationTestClass
    {
        
        [Fact]
        public async Task GetAll_Address()
        {
            //arrange
            const string URL_ADDRESS = "http://localhost:5024/Address";

            //act
            var response = await _testClient.GetAsync(URL_ADDRESS); 
            var address = await _testClient.GetFromJsonAsync<List<Address>>(URL_ADDRESS);


            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(address);
            Assert.True(address.Count == 1);

            //(await response.Content.

            
        }
    }
}
