using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsersAPI.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
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