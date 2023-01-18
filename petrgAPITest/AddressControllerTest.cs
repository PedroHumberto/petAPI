using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using petrgAPI.Controllers;
using petrgAPI.Data;
using petrgAPI.Data.Dto.AddressDto;
using petrgAPI.Profiles;
using petrgAPI.Services;
using PetRGTest;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrgAPITest
{
    public class AddressControllerTest
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange
            DbContextOptionsBuilder<AppDbContext> _optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("TestDb");
            AppDbContext _context = new AppDbContext(_optionsBuilder.Options);
            MapperConfiguration _config = new MapperConfiguration(cfg => cfg.AddProfile<AddressProfile>());
            IMapper _mapper = _config.CreateMapper();
            AddressService _addressService = new AddressService(_context, _mapper);
            var _targetTest = new AddressController(_addressService);

            //Act
            await _targetTest.AddAddress(new CreateAddressDto { City = "teste 1", Country = "Teste 2", State = "Teste 3", Street = "teste 4" });
            var result = (OkObjectResult)_targetTest.GetAddresses();

            //Assert
            result.StatusCode.ShouldBe(200);
        }




        

    }
}
