using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using petrgAPI.Controllers;
using petrgAPI.Data;
using petrgAPI.Data.Dto.AddressDto;
using petrgAPI.Profiles;
using petrgAPI.Services.Interfaces;
using petrgAPITest.Fixture;
using Shouldly;
using System.Net.Sockets;

namespace petrgAPITest
{
    public class AddressControllerTest
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange
            DbContextOptionsBuilder<AppDbContext> _optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("ControllerTestDb");
            AppDbContext _context = new AppDbContext(_optionsBuilder.Options);
            MapperConfiguration _config = new MapperConfiguration(cfg => cfg.AddProfile<AddressProfile>());
            IMapper _mapper = _config.CreateMapper();
            
            var _mockAddressService = new Mock <IAddressService>();
            _mockAddressService.Setup(service => service.GetAllAsync())
                .ReturnsAsync(AddressesFixture.GetAddressesTest());

            var _targetTest = new AddressController(_mockAddressService.Object);

            //Act
            var result = (OkObjectResult) await _targetTest.GetAddresses();

            //Assert
            result.StatusCode.ShouldBe(200);
        }




        

    }
}
