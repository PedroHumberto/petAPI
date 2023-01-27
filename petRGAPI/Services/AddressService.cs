
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using petrgAPI.Data;
using petrgAPI.Data.Dto.AddressDto;
using petrgAPI.Models;

namespace petrgAPI.Services
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

        public async Task<List<ReadAddressDto>> GetAllAsync()
        {
                List<Address> addresses = await _context.Addresses.ToListAsync();
                List<ReadAddressDto> addressDto = _mapper.Map<List<ReadAddressDto>>(addresses);

                if (addresses.IsNullOrEmpty())
                {
                    throw new Exception("Empty Database");
                }

                return addressDto;
        }

        public async Task<ReadAddressDto> AddAddressAsync(CreateAddressDto addressDto)
        {
            Address address = _mapper.Map<Address>(addressDto);

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReadAddressDto>(address);
        }

       

        public async Task<ReadAddressDto> getById(int id)
        {
            Address address = await _context.Addresses.FirstOrDefaultAsync(address => address.Id == id);
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