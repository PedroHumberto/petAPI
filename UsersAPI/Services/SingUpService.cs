using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsersApi.Models;
using UsersAPI.Data;
using UsersAPI.Data.Dto;
using UsersAPI.Data.Requests;

namespace UsersAPI.Services
{
    public class SingUpService
    {
        IMapper _mapper;
        UserDbContext _context;
        UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;

        public SingUpService(IMapper mapper, UserDbContext context, UserManager<IdentityUser<int>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<Result> SingUpUser(CreateUserDto createDto)
        {
            User user = _mapper.Map<User>(createDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> identityResult = _userManager
                .CreateAsync(userIdentity, createDto.Password);

            if (identityResult.Result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(userIdentity);
                _emailService.SendEmail(new[] {userIdentity.Email}, "Activation Link", userIdentity.Id, code);
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("SingUp Failed");
        }

        public Result AccountActivation(ActiveAccountRequest request)
        {
            var IdentityUser = _userManager.Users.FirstOrDefault( user => user.Id == request.UserId);
            var identityResult = _userManager.ConfirmEmailAsync(IdentityUser, request.ActivationCode).Result;
            if(identityResult.Succeeded){
                return Result.Ok();
            }
            return Result.Fail("Activation Failed");
        }
    }
}