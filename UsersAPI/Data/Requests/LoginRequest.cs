
using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Data.Requests
{
    public class LoginRequest{
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}