using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PETRGAPI.USERS.Models;
using System.Web;
using UsersApi.Models;
using UsersAPI.Data.Dto;
using UsersAPI.Data.Requests;

namespace UsersAPI.Services
{
    public class SingUpService
    {
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailService;

        public SingUpService(IMapper mapper, 
            UserManager<CustomIdentityUser> userManager,
            EmailService emailService
            )
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            
        }

        public async Task<Result> SingUpUser(CreateUserDto createDto)
        {
            User user = _mapper.Map<User>(createDto);
            CustomIdentityUser userIdentity = _mapper.Map<CustomIdentityUser>(user);
            IdentityResult identityResult = await _userManager
                .CreateAsync(userIdentity, createDto.Password);

            await _userManager.AddToRoleAsync(userIdentity, "regular");

            if (identityResult.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(userIdentity);
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.SendEmail(new[] {userIdentity.Email}, "Activation Link", userIdentity.Id, encodedCode);
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("SingUp Failed");
        }

        public async Task<Result> AccountActivation(ActiveAccountRequest request)
        {
            var IdentityUser = await _userManager.Users.FirstOrDefaultAsync( user => user.Id == request.UserId);

            var identityResult = await _userManager.ConfirmEmailAsync(IdentityUser, request.ActivationCode);

            if(identityResult.Succeeded){
                return Result.Ok();
            }
            return Result.Fail("Activation Failed");
        }
    }
}