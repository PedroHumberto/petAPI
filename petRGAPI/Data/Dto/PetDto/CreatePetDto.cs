
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using petrgAPI.Models;

namespace petrgAPI.Data.Dto.PetDto
{
    public class CreatePetDto{
        
        public string PetName { get; set; }
        public DateTime PetBirthDay { get; set; }
        public string PetBreed {get; set; }
        public int PetGuardianId { get; set; }

    }
}