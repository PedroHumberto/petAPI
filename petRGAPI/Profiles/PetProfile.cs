using AutoMapper;
using petrgAPI.Data.Dto.PetDto;
using petrgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<CreatePetDto, Pet>();
            CreateMap<Pet, ReadPetDto>();
            CreateMap<UpdatePetDto, Pet>();
        }
    }
}