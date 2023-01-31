
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UserAPI.Models;
using UsersAPI.Data.Requests;


namespace UsersAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result UserLog(LoginRequest request)
        {
            var resultIdentity = _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultIdentity.Result.Succeeded)
            {

                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(user => user.NormalizedUserName == request.Username.ToUpper());

                Token token = _tokenService.CreateToken(identityUser);  
                Console.WriteLine($"Token: {token.Value}");                  
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login Failed");
        }
    }
}