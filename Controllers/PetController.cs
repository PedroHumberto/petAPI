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

    public PetController(AppDbContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
        public IActionResult AddCinema([FromBody] CreatePetDto petDto)
        {
            Pet pet = _mapper.Map<Pet>(petDto);

            _context.Pets.Add(pet);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPetById), new { Id = pet.Id }, pet); // "https://localhost:5000/Filmes/1"
        }
         [HttpGet("{id}")]
        public IActionResult GetPetById(int id)
        {
            Pet pet = _context.Pets.FirstOrDefault(filme => filme.Id == id);

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
}
