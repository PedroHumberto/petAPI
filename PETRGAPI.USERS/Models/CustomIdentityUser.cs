using Microsoft.AspNetCore.Identity;

namespace PETRGAPI.USERS.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime BirthDate { get; set; }
    }
}
