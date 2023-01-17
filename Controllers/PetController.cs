using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using PetRGAPI.Data;
using PetRGAPI.Data.Dto.PetDto;
using PetRGAPI.Models;
using PetRGAPI.Services;
using PetRGAPI.Services.Interfaces;

namespace PetRGAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : ControllerBase
{

    private IPetService _petService;

    public PetController(IPetService petService)
    {
        _petService = petService;
    }

    [HttpGet]
    public IActionResult GetPets()
    {
        List<ReadPetDto> allPets = _petService.GetAll();

        return Ok(allPets);
    }

    [HttpPost]
    public async Task<IActionResult> AddPet([FromBody] CreatePetDto creatDto)
    {
        Task<ReadPetDto> readDto = _petService.AddPetAsync(creatDto);

        return CreatedAtAction(nameof(GetPetById), new { Id = readDto.Id }, await readDto); // "https://localhost:5000/Pets/1"
    }

    [HttpGet("{id}")]
    public IActionResult GetPetById(int id)
    {
        ReadPetDto readDto = _petService.getById(id);
        if (readDto != null) return Ok(readDto);

        return NotFound();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePet(int id)
    {
        Task<Result> result = _petService.Delete(id);
        if(result.GetAwaiter().GetResult().IsFailed) return NotFound();
        return NoContent();
    }


}
