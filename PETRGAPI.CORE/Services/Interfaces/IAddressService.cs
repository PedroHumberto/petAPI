using FluentResults;
using petrgAPI.Data.Dto.AddressDto;
using petrgAPI.Data.Dto.PetDto;

namespace petrgAPI.Services.Interfaces
{
    public interface IAddressService
    {
        Task<List<ReadAddressDto>> GetAllAsync();
        Task<ReadAddressDto> AddAddressAsync(CreateAddressDto creatDto);
        Task<ReadAddressDto> getByIdAsync(int id);
        Task<Result> Delete(int id);
    }
}
