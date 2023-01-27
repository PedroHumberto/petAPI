using FluentResults;
using petrgAPI.Data.Dto.PetDto;

namespace petrgAPI.Services.Interfaces{
    public interface IPetService{
        Task<ReadPetDto> AddPetAsync(CreatePetDto creatDto);
        Task<List<ReadPetDto>> GetAllAsync();
        Task<ReadPetDto> getByIdAsync(int id);
        Task<Result> Delete(int id);
    }
}