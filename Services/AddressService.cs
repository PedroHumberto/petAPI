
using AutoMapper;
using FluentResults;
using PetRGAPI.Data;
using PetRGAPI.Data.Dto.AddressDto;
using PetRGAPI.Models;

namespace PetRGAPI.Services
{
    public class AddressService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AddressService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadAddressDto> AddAddressAsync(CreateAddressDto addressDto)
        {
            Address address = _mapper.Map<Address>(addressDto);

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReadAddressDto>(address);
        }

        public List<ReadAddressDto> GetAll()
        {
            List<Address> addresses = _context.Addresses.ToList();
            List<ReadAddressDto> addressDto = _mapper.Map<List<ReadAddressDto>>(addresses);

            return addressDto;

        }

        public ReadAddressDto getById(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address != null)
            {
                ReadAddressDto addressDto = _mapper.Map<ReadAddressDto>(address);

                return addressDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<Result> Delete(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return Result.Fail("address doesn't exist");
            }
            _context.Remove(address);

            await _context.SaveChangesAsync();

            return Result.Ok();

        }
    }
}