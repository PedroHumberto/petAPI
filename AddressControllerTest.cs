using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using petrgAPI.Models;
using Shouldly;

using System.Net;
using System.Net.Http.Json;
using petrgAPI.Data.Dto.AddressDto;
using System.Net.Http;
using petrgAPI.Routes;

namespace PetRGTest
{
    public class AddressControllerTest : IntegrationTestClass
    {

        [Fact]
        public async Task GetAll_Address()
        {
            //arrange
            string URL_ADDRESS = ApiRoutes.Address.GetAll;

            //act
            var response = await _testClient.GetAsync(URL_ADDRESS);
            var address = await _testClient.GetFromJsonAsync<List<Address>>(URL_ADDRESS);


            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(address);
            Assert.True(address.Count >= 0);
        }

        [Fact]
        public async Task Get_ReturnsAddress()
        {

            //arrange
            string URL_ADDRESS = ApiRoutes.Address.GetAll;
            var createdAddress = await AddAddressAsync(new CreateAddressDto { Country = "Teste 111", State = "Teste 1111", City = "Teste 1111", Street = "Teste 1111" });


            //Act
            var address = await _testClient.GetFromJsonAsync<List<Address>>(URL_ADDRESS);
            var lastId = address.Last().Id;

            var response = await _testClient.GetAsync(ApiRoutes.Address.Get(lastId));

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedAddress = await response.Content.ReadAsAsync<ReadAddressDto>();

            returnedAddress.Id.ShouldBe(lastId);
            returnedAddress.Country.ShouldBe(returnedAddress.Country);


        }
    }
}
