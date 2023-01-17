
using PetRGAPI.Models;

namespace PetRGAPI.Data.Dto.PetGuardianDto
{
    public class ReadPetGuardianDto
    {
        public string Name { get; set; }
        public Address address { get; set; }
        public string phoneNumber { get; set; }
        public object Pets { get; set; }
    }
}