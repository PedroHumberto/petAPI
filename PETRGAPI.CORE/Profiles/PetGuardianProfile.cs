

using AutoMapper;
using petrgAPI.Data.Dto.PetGuardianDto;
using petrgAPI.Models;

namespace FilmesAPI.Profiles{
    public class PetGuardianProfile : Profile{
        public PetGuardianProfile(){
            CreateMap<CreatePetGuardianDto, PetGuardian>();
            CreateMap<PetGuardian, ReadPetGuardianDto>();
            CreateMap<UpdatePetGuardianDto, PetGuardian>();
        }
    }
}