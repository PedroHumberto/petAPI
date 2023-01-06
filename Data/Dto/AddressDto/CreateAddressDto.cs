using petrgAPI.Models;

namespace petrgAPI.Data.Dto.AddressDto{
    public class CreateAddressDto{
      
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

    }
}