
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PetRGAPI.Models
{
    public class Pet{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string PetName { get; set; }
        public DateTime PetBirthDay { get; set; }
        public string PetBreed {get; set; }
        
        [JsonIgnore]
        public int PetGuardianId { get; set; }
        [JsonIgnore]
        public virtual PetGuardian PetGuardian {get; set;}

    }
}