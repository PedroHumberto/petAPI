
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetRGAPI.Models
{
    public class PetGuardian
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string phoneNumber { get; set; }
        public virtual Address Address { get; set; }
        [JsonIgnore]
        public int? AddresId { get; set; }
        [JsonIgnore]
        public virtual List<Pet> Pets { get; set; }
    }
}