
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using petrgAPI.Data;
using petrgAPI.Data.Dto.PetDto;
using petrgAPI.Models;
using petrgAPI.Services.Interfaces;

namespace petrgAPI.Services
{
    public class PetService : IPetService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public PetService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadPetDto> AddPetAsync(CreatePetDto creatDto)
        {
            Pet pet = _mapper.Map<Pet>(creatDto);

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReadPetDto>(pet);
        }

        public async  Task<List<ReadPetDto>> GetAllAsync()
        {
            List<Pet> pets = await _context.Pets.ToListAsync();
            List<ReadPetDto> addressDto = _mapper.Map<List<ReadPetDto>>(pets);

            return addressDto;

        }

        public async Task<ReadPetDto> getByIdAsync(int id)
        {
            Pet pet = await _context.Pets.FirstOrDefaultAsync(pet => pet.Id == id);
            if (pet != null)
            {
                ReadPetDto readDto = _mapper.Map<ReadPetDto>(pet);

                return readDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<Result> Delete(int id)
        {
            Pet pet = _context.Pets.FirstOrDefault(pet => pet.Id == id);
            if (pet == null)
            {
                return Result.Fail("address doesn't exist");
            }
            _context.Remove(pet);

            await _context.SaveChangesAsync();

            return Result.Ok();

        }
    }
}