using FluentResults;
using petrgAPI.Data.Dto.PetDto;

namespace petrgAPI.Services.Interfaces{
    public interface IPetService{
        Task<ReadPetDto> AddPetAsync(CreatePetDto creatDto);
        List<ReadPetDto> GetAll();
        ReadPetDto getById(int id);
        Task<Result> Delete(int id);
    }
}