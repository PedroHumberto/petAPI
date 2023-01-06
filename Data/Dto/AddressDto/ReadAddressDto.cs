using System.Text.Json.Serialization;
using petrgAPI.Models;

namespace petrgAPI.Data.Dto.AddressDto{
    public class ReadAddressDto{
        public int Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

    }
}