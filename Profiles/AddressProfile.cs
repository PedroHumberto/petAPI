
using AutoMapper;
using petrgAPI.Data.Dto.AddressDto;
using petrgAPI.Models;

namespace petrgAPI.Profiles{
    public class AddressProfile : Profile{
       public AddressProfile(){
            CreateMap<CreateAddressDto, Address>();
            CreateMap<Address, ReadAddressDto>();
            CreateMap<UpdateAddressDto, Address>();
        }
    }
}