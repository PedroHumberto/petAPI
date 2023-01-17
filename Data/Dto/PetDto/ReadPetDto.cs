
using System.ComponentModel.DataAnnotations;
using PetRGAPI.Models;

namespace PetRGAPI.Data.Dto.PetDto
{
    public class ReadPetDto{
        
        public string PetName { get; set; }
        public DateTime PetBirthDay { get; set; }
        public string PetBreed {get; set; }
        public PetGuardian PetGuardian {get; set;}
    }
}