
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace petrgAPI.Models
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
        public int AddresId { get; set; }
        public virtual List<Pet> Pets { get; set; }
    }
}