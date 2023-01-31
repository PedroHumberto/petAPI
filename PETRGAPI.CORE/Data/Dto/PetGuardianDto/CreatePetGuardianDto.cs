
using petrgAPI.Models;

namespace petrgAPI.Data.Dto.PetGuardianDto
{
    public class CreatePetGuardianDto
    {
        public string Name { get; set; }
        public int? AddresId { get; set; }
        public string phoneNumber { get; set; }
       
    }
}