
using System.ComponentModel.DataAnnotations;
using PetRGAPI.Models;

namespace PetRGAPI.Data.Dto.PetDto
{
    public class UpdatePetDto{
        
        public string PetName { get; set; }
        public DateTime PetBirthDay { get; set; }
        public string PetBreed {get; set; }
        public int PetGuardianId { get; set; }
        public virtual PetGuardian PetGuardian {get; set;}

    }
}