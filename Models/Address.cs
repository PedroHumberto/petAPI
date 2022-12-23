
using System.ComponentModel.DataAnnotations;

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
        public virtual PetGuardian PetGuardian {get; set;}
    }
}