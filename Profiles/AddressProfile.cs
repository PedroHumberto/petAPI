
using AutoMapper;
using PetRGAPI.Data.Dto.AddressDto;
using PetRGAPI.Models;

namespace PetRGAPI.Profiles{
    public class AddressProfile : Profile{
       public AddressProfile(){
            CreateMap<CreateAddressDto, Address>();
            CreateMap<Address, ReadAddressDto>();
            CreateMap<UpdateAddressDto, Address>();
        }
    }
}