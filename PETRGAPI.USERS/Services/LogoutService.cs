using FluentResults;
using Microsoft.AspNetCore.Identity;
using PETRGAPI.USERS.Models;

namespace UsersAPI.Services
{
    public class LogoutService
    {
        private SignInManager<CustomIdentityUser> _signInManager;

        public LogoutService(SignInManager<CustomIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogoutUser(){
            var resultIdentity = _signInManager.SignOutAsync();
            if(resultIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Logout Failed!");
        }
    }
}