using Microsoft.AspNetCore.Authorization;

namespace PETRGAPI.CORE.Authorization
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MiminumAge { get; set; }

        public MinimumAgeRequirement(int miminumAge)
        {
            MiminumAge = miminumAge;
        }
    }
}
