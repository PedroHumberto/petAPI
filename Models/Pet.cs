
using System.ComponentModel.DataAnnotations;

namespace petrgAPI.Models
{
    public class Pet{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string PetName { get; set; }
        public DateTime PetBirthDay { get; set; }
        public string PetBreed {get; set; }
        public int PetGuardianId { get; set; }
        public virtual PetGuardian PetGuardian {get; set;}

    }
}