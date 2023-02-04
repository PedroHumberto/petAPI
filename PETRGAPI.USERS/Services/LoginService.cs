
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PETRGAPI.USERS.Data.Requests;
using PETRGAPI.USERS.Models;
using UserAPI.Models;
using UsersAPI.Data.Requests;


namespace UsersAPI.Services
{
    public class LoginService
    {
        private SignInManager<CustomIdentityUser> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<Result> UserLog(LoginRequest request)
        {
            var resultIdentity = _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

            if (resultIdentity.Result.Succeeded)
            {

                var identityUser = await _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefaultAsync(user => user.NormalizedUserName == request.Username.ToUpper());

                try {

                    var role = await _signInManager.UserManager.GetRolesAsync(identityUser);

                    Console.WriteLine("Role " + role.Count);
                    Console.WriteLine("IdentituUser " + identityUser.ToString());

                    Token token = _tokenService
                     .CreateToken(identityUser, _signInManager
                                 .UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());

                    return Result.Ok().WithSuccess(token.Value);
                }
                catch (ArgumentNullException ex) {

                    Console.WriteLine(ex.Message);
                        
                }
                  
                       
                
            }
            return Result.Fail("Login Failed");
        }

        public async Task<Result> ResetPasswordRequestAsync(ResetRequest request)
        {
            CustomIdentityUser identityUser = await GetUserByEmailAsync(request.Email);

            if (identityUser != null)
            {
                string resetCodeToken = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(resetCodeToken);
            }
            return Result.Fail("Fail in request");

        }

        public async Task<Result> ResetPasswordAsync(PasswordReset request)
        {
            CustomIdentityUser identityUser = await GetUserByEmailAsync(request.Email);

            IdentityResult identityResult = await _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password);

            if (identityResult.Succeeded) return Result.Ok().WithSuccess("successfully reset password reset");

            return Result.Fail("Something Goes Wrong");
        }

        private async Task<CustomIdentityUser> GetUserByEmailAsync(string email)
        {
            return await _signInManager
                .UserManager
                .Users
                .FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}