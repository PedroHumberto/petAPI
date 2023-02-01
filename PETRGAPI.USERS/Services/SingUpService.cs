using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Web;
using UsersApi.Models;
using UsersAPI.Data;
using UsersAPI.Data.Dto;
using UsersAPI.Data.Requests;

namespace UsersAPI.Services
{
    public class SingUpService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;


        public SingUpService(IMapper mapper, 
            UserManager<IdentityUser<int>> userManager,
            EmailService emailService, 
            RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public async Task<Result> SingUpUser(CreateUserDto createDto)
        {
            User user = _mapper.Map<User>(createDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            IdentityResult identityResult = await _userManager
                .CreateAsync(userIdentity, createDto.Password);

            await _userManager.AddToRoleAsync(userIdentity, "admin");

            var createRoleResult = _roleManager.CreateAsync(new IdentityRole<int>("admin")).Result;

            

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