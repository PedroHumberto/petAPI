
using petrgAPI.Models;

namespace petrgAPI.Data.Dto.PetGuardianDto
{
    public class ReadPetGuardianDto
    {
        public string Name { get; set; }
        public int AddresId { get; set; }
        public Address address { get; set; }
        public string phoneNumber { get; set; }
        public object Pets { get; set; }
    }
}