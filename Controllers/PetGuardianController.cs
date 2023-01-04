using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using petrgAPI.Data;
using petrgAPI.Data.Dto.PetGuardianDto;
using petrgAPI.Models;

namespace petrgAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PetGuardianController : ControllerBase
{
    private AppDbContext _context;
    private IMapper _mapper;

    public PetGuardianController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetPetGuardians()
    {
        List<PetGuardian> petGuardian = _context.PetGuardians.ToList();

        List<ReadPetGuardianDto> petGuardianDto = _mapper.Map<List<ReadPetGuardianDto>>(petGuardian);

        return Ok(petGuardianDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddPetGuardian([FromBody] CreatePetGuardianDto petGuardianDto)
    {
        PetGuardian petGuardian = _mapper.Map<PetGuardian>(petGuardianDto);

        _context.PetGuardians.Add(petGuardian);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPetGuardianById), new { Id = petGuardian.Id }, petGuardian); // "https://localhost:5000/Pets/1"
    }


    [HttpGet("{id}")]
    public IActionResult GetPetGuardianById(int id)
    {
        PetGuardian petGuardian = _context.PetGuardians.FirstOrDefault(petGuardian => petGuardian.Id == id);
        if (petGuardian != null)
        {
            ReadPetGuardianDto petGuardianDto = _mapper.Map<ReadPetGuardianDto>(petGuardian);

            return Ok(petGuardianDto);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePetGuardian(int id)
    {
        PetGuardian petGuardian = _context.PetGuardians.FirstOrDefault(petGuardian => petGuardian.Id == id);
        if (petGuardian != null)
        {
            _context.Remove(petGuardian);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }


}
