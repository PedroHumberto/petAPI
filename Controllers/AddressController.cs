using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using PetRGAPI.Data;
using PetRGAPI.Data.Dto.AddressDto;
using PetRGAPI.Data.Dto.PetGuardianDto;
using PetRGAPI.Models;
using PetRGAPI.Services;

namespace PetRGAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{

    private AddressService _addressService;
    public AddressController(AddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    public IActionResult GetAddress()
    {
        List<ReadAddressDto> allAddresses =_addressService.GetAll();
        return Ok(allAddresses);
    }

    [HttpPost]
    public async Task<IActionResult> AddAddress([FromBody] CreateAddressDto addressDto)
    {
        Task<ReadAddressDto> readDto =_addressService.AddAddressAsync(addressDto);  
        return CreatedAtAction(nameof(GetAddressById), new { Id = readDto.Id }, await readDto); // "https://localhost:5000/Pets/1"
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(int id)
    {
        ReadAddressDto readDto = _addressService.getById(id);
        
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
