

using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using petrgAPI.Data;
using petrgAPI.Data.Dto.PetGuardianDto;
using petrgAPI.Models;

namespace petrgAPI.Services
{
    public class PetGuardianService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public PetGuardianService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadPetGuardianDto> AddPetGuardianAsync(CreatePetGuardianDto creatDto)
        {
            PetGuardian petGuardian = _mapper.Map<PetGuardian>(creatDto);

            await _context.PetGuardians.AddAsync(petGuardian);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReadPetGuardianDto>(petGuardian);
        }

        public async Task<List<ReadPetGuardianDto>> GetAllAsync()
        {
            List<PetGuardian> petGuardians = await _context.PetGuardians.ToListAsync();

            List<ReadPetGuardianDto> readDto = _mapper.Map<List<ReadPetGuardianDto>>(petGuardians);

            return readDto;

        }

        public async Task<ReadPetGuardianDto> getById(int id)
        {
            PetGuardian petGuardian = await _context.PetGuardians.FirstOrDefaultAsync(petGuardian => petGuardian.Id == id);

            if (petGuardian != null)
            {
                ReadPetGuardianDto readDto = _mapper.Map<ReadPetGuardianDto>(petGuardian);
                return readDto;
            }
            else return null;

        }

        public async Task<Result> Delete(int id)
        {
            PetGuardian petGuardian = _context.PetGuardians.FirstOrDefault(petGuardian => petGuardian.Id == id);
            if (petGuardian == null)
            {
                return Result.Fail("address doesn't exist");
            }
            _context.Remove(petGuardian);
            
            await _context.AddRangeAsync();

            return Result.Ok();
        }



    }
}