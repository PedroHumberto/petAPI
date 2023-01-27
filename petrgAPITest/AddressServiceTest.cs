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
using Microsoft.EntityFrameworkCore;
using petrgAPI.Data;
using petrgAPI.Services;
using AutoMapper;
using petrgAPI.Profiles;
using petrgAPI.Controllers;
using Microsoft.Extensions.Options;

namespace PetRGTest
{
    public class AddressServiceTest
    {
        
        [Fact]
        public async Task Get_EmptyDatabase_ShouldThrow_Message()
        {

            //Arrange
            DbContextOptionsBuilder<AppDbContext> _optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("EmptyDBTest");
            AppDbContext _context = new AppDbContext(_optionsBuilder.Options);
            MapperConfiguration _config = new MapperConfiguration(cfg => cfg.AddProfile<AddressProfile>());
            IMapper _mapper = _config.CreateMapper();
            AddressService _testTarget = new AddressService(_context, _mapper);

            //Act
            var erro = _testTarget.GetAllAsync;
            var message = await Assert.ThrowsAsync<Exception>(erro);

            //Assert
            Assert.Equal("Empty Database", message.Message);
            
        }

        [Fact]
        public async Task Get_AllDatabase()
        {
            //Arrange
            DbContextOptionsBuilder<AppDbContext> _optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("TestDb");
            AppDbContext _context = new AppDbContext(_optionsBuilder.Options);
            MapperConfiguration _config = new MapperConfiguration(cfg => cfg.AddProfile<AddressProfile>());
            IMapper _mapper = _config.CreateMapper();
            AddressService _testTarget = new AddressService(_context, _mapper);

            //act
            await _testTarget.AddAddressAsync(new CreateAddressDto{City = "teste 1", Country = "Teste 2", State = "Teste 3", Street = "teste 4"});
            await _testTarget.AddAddressAsync(new CreateAddressDto { City = "ABC", Country = "AAA 2", State = "aSDAS 3", Street = "ASDASDD 4" });
            await _testTarget.AddAddressAsync(new CreateAddressDto { City = "teste 1", Country = "Strasdasd 2", State = "Teste 3", Street = "teste 4" });
            await _testTarget.AddAddressAsync(new CreateAddressDto { City = "AASdasd 1", Country = "ASDASD 2", State = "ASaSDe 3", Street = "teste 4" });
            await _testTarget.AddAddressAsync(new CreateAddressDto { City = "teste 1", Country = "Teste 2", State = "Teste 3", Street = "teste 4" });
            await _testTarget.AddAddressAsync(new CreateAddressDto { City = "teste 1", Country = "Teste 2", State = "Teste 3", Street = "teste 4" });
            var getAll = await _testTarget.GetAllAsync();

            //Assert
            Assert.True(getAll.Count > 0);

        }

        [Fact]
        public async Task Post_AddressInDatabase_ShouldBe_TheLast_Id()
        {
            //Arrange
            DbContextOptionsBuilder<AppDbContext> _optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("GetIdTestDb");
            AppDbContext _context = new AppDbContext(_optionsBuilder.Options);
            MapperConfiguration _config = new MapperConfiguration(cfg => cfg.AddProfile<AddressProfile>());
            IMapper _mapper = _config.CreateMapper();
            AddressService _testTarget = new AddressService(_context, _mapper);

            //Act
            var addAdress = await _testTarget.AddAddressAsync(new CreateAddressDto { City = "teste 1", Country = "Teste 2", State = "Teste 3", Street = "teste 4" });
            var getAll = await _testTarget.GetAllAsync();
            
            
            //Assert
            addAdress.Id.ShouldBe(getAll.Last().Id);

        }

    }
}