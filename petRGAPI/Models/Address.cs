
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace petrgAPI.Models
{
    public class Address{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        [JsonIgnore]
        public virtual PetGuardian PetGuardian {get; set;} 
    }
}