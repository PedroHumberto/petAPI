using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using petrgAPI.Data;
using petrgAPI.Data.Dto.AddressDto;
using petrgAPI.Data.Dto.PetGuardianDto;
using petrgAPI.Models;

namespace petrgAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private AppDbContext _context;
    private IMapper _mapper;

    public AddressController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddAddress([FromBody] CreateAddressDto addressDto)
    {
        Address address = _mapper.Map<Address>(addressDto);

        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAddressById), new { Id = address.Id }, address); // "https://localhost:5000/Pets/1"
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(int id)
    {
        Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address != null)
        {
            ReadAddressDto addressDto = _mapper.Map<ReadAddressDto>(address);

            return Ok(addressDto);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddress(int id)
    {
        Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address != null)
        {
            _context.Remove(address);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }


}
