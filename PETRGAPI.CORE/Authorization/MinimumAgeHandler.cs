using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PETRGAPI.CORE.Authorization
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            //if the user doesn't has DateOfBirth return CompletedTask, but not Authorized
            if(!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth)) return Task.CompletedTask;

            DateTime birthDate = Convert.ToDateTime(context.User.FindFirst(c =>
                c.Type == ClaimTypes.DateOfBirth
            ).Value);


            int age = DateTime.Today.Year - birthDate.Year;

            if(birthDate > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            if (age >= requirement.MiminumAge)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
