
using System.ComponentModel.DataAnnotations;
using petrgAPI.Models;

namespace petrgAPI.Data.Dto.PetDto
{
    public class ReadPetDto{
        
        public string PetName { get; set; }
        public DateTime PetBirthDay { get; set; }
        public string PetBreed {get; set; }
        public int PetGuardianId { get; set; }
        public PetGuardian PetGuardian {get; set;}
    }
}