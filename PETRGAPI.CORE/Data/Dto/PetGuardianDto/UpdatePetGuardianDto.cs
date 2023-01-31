
using petrgAPI.Models;

namespace petrgAPI.Data.Dto.PetGuardianDto
{
    public class UpdatePetGuardianDto
    {
        public string Name { get; set; }
        public int AddresId { get; set; }
        public string phoneNumber { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Pet> Pets { get; set; }
    }
}