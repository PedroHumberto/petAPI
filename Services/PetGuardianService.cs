

using AutoMapper;
using FluentResults;
using PetRGAPI.Data;
using PetRGAPI.Data.Dto.PetGuardianDto;
using PetRGAPI.Models;

namespace PetRGAPI.Services
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

        public List<ReadPetGuardianDto> GetAll()
        {
            List<PetGuardian> petGuardians = _context.PetGuardians.ToList();

            List<ReadPetGuardianDto> readDto = _mapper.Map<List<ReadPetGuardianDto>>(petGuardians);

            return readDto;

        }

        public ReadPetGuardianDto getById(int id)
        {
            PetGuardian petGuardian = _context.PetGuardians.FirstOrDefault(petGuardian => petGuardian.Id == id);

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