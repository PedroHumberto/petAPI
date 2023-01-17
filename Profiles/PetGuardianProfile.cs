

using AutoMapper;
using PetRGAPI.Data.Dto.PetGuardianDto;
using PetRGAPI.Models;

namespace PetRGAPI.Profiles{
    public class PetGuardianProfile : Profile{
        public PetGuardianProfile(){
            CreateMap<CreatePetGuardianDto, PetGuardian>();
            CreateMap<PetGuardian, ReadPetGuardianDto>();
            CreateMap<UpdatePetGuardianDto, PetGuardian>();
        }
    }
}