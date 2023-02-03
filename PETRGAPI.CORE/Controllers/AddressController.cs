using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using petrgAPI.Data;
using petrgAPI.Data.Dto.AddressDto;
using petrgAPI.Data.Dto.PetGuardianDto;
using petrgAPI.Models;
using petrgAPI.Services;
using petrgAPI.Services.Interfaces;

namespace petrgAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{

    private IAddressService _addressService;
    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAddresses()
    {
        List<ReadAddressDto> allAddresses = await _addressService.GetAllAsync();

        if(allAddresses.IsNullOrEmpty())
        {
            return NotFound();
        }


        return Ok(allAddresses);
    }


    
    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> AddAddress([FromBody] CreateAddressDto addressDto)
    {
        Task<ReadAddressDto> readDto =_addressService.AddAddressAsync(addressDto);  
        return CreatedAtAction(nameof(GetAddressById), new { Id = readDto.Id }, await readDto); // "https://localhost:5000/Pets/1"
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        ReadAddressDto readDto = await _addressService.getByIdAsync(id);
        
        if (readDto != null)
        {
            return Ok(readDto);
        }
        else
        {
            return NotFound();
        }
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        Task<Result> result = _addressService.Delete(id);
        if (result.GetAwaiter().GetResult().IsFailed) return NotFound();
        return NoContent();
    }


}
