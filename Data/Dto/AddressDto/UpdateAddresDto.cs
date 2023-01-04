using petrgAPI.Models;

namespace petrgAPI.Data.Dto.AddressDto{
    public class UpdateAddressDto{
      
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public virtual PetGuardian PetGuardian {get; set;}
    }
}