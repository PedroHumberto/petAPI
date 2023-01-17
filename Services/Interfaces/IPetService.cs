using FluentResults;
using PetRGAPI.Data.Dto.PetDto;

namespace PetRGAPI.Services.Interfaces{
    public interface IPetService{
        Task<ReadPetDto> AddPetAsync(CreatePetDto creatDto);
        List<ReadPetDto> GetAll();
        ReadPetDto getById(int id);
        Task<Result> Delete(int id);
    }
}