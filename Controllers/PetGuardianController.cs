using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using PetRGAPI.Data;
using PetRGAPI.Data.Dto.PetGuardianDto;
using PetRGAPI.Models;
using PetRGAPI.Services;

namespace PetRGAPI.Controllers;

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
    public IActionResult GetPetGuardians()
    {
        List<ReadPetGuardianDto> allPetGuardians = _petGuardianService.GetAll();

        return Ok(allPetGuardians);
    }

    [HttpPost]
    public async Task<IActionResult> AddPetGuardian([FromBody] CreatePetGuardianDto petGuardianDto)
    {
        Task<ReadPetGuardianDto> readDto = _petGuardianService.AddPetGuardianAsync(petGuardianDto);
        return CreatedAtAction(nameof(GetPetGuardianById), new { Id = readDto.Id }, await readDto); // "https://localhost:5000/Pets/1"
    }


    [HttpGet("{id}")]
    public IActionResult GetPetGuardianById(int id)
    {
        ReadPetGuardianDto readDto = _petGuardianService.getById(id);

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
