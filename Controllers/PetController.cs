using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using petrgAPI.Data;
using petrgAPI.Data.Dto.PetDto;
using petrgAPI.Models;

namespace petrgAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : ControllerBase
{
    private AppDbContext _context;
    private IMapper _mapper;

    public PetController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetPets()
    {
        List<Pet> pets = _context.Pets.ToList();

        List<ReadPetDto> petDto = _mapper.Map<List<ReadPetDto>>(pets);

        return Ok(petDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddPet([FromBody] CreatePetDto petDto)
    {
        Pet pet = _mapper.Map<Pet>(petDto);

        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPetById), new { Id = pet.Id }, pet); // "https://localhost:5000/Pets/1"
    }

    [HttpGet("{id}")]
    public IActionResult GetPetById(int id)
    {
        Pet pet = _context.Pets.FirstOrDefault(pet => pet.Id == id);
        if (pet != null)
        {
            ReadPetDto petDto = _mapper.Map<ReadPetDto>(pet);

            return Ok(petDto);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePet(int id)
    {
        Pet pet = _context.Pets.FirstOrDefault(pet => pet.Id == id);
        if (pet != null)
        {
            _context.Remove(pet);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }


}
