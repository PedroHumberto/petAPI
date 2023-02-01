using System.ComponentModel.DataAnnotations;

namespace PETRGAPI.USERS.Data.Requests
{
    public class ResetRequest
    {

        [Required]
        public string Email { get; set; }

    }
}
