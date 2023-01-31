using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using petrgAPI.Data;
using petrgAPI.Data.Dto.PetGuardianDto;
using petrgAPI.Models;
using petrgAPI.Services;

namespace petrgAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PetGuardianController : ControllerBase
{
    private PetGuardianService _petGuardianService;


    public PetGuardianController(PetGuardianService petGuardianService)
    {
        _petGuardianService = petGuardianService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPetGuardians()
    {
        List<ReadPetGuardianDto> allPetGuardians = await _petGuardianService.GetAllAsync();
        if (allPetGuardians.IsNullOrEmpty())
        {
            return NotFound();
        }

        return Ok(allPetGuardians);
    }

    [HttpPost]
    public async Task<IActionResult> AddPetGuardian([FromBody] CreatePetGuardianDto petGuardianDto)
    {
        Task<ReadPetGuardianDto> readDto = _petGuardianService.AddPetGuardianAsync(petGuardianDto);
        return CreatedAtAction(nameof(GetPetGuardianById), new { Id = readDto.Id }, await readDto); // "https://localhost:5000/Pets/1"
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetPetGuardianById(int id)
    {
        ReadPetGuardianDto readDto = await _petGuardianService.getByIdAsync(id);

        if (readDto != null) return Ok(readDto);

        return NotFound();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePetGuardian(int id)
    {
        Task<Result> result = _petGuardianService.Delete(id);
        if (result.GetAwaiter().GetResult().IsFailed) return NotFound();

        return NoContent();
    }


}
