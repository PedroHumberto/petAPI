using FluentResults;
using Microsoft.AspNetCore.Mvc;
using PETRGAPI.USERS.Data.Requests;
using UsersAPI.Data.Requests;
using UsersAPI.Services;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginRequest request)
        {
            Result result = await _loginService.UserLog(request);
            if (result.IsFailed)
            {
                IError error = result.Errors[0];
                return Unauthorized(error);
            }
            ISuccess success = result.Successes[0];


            return Ok(success);
        } 

        [HttpPost("/password-reset-request")]
        public async Task<IActionResult> PasswordUserResetRequest(ResetRequest request)
        {
            Result result = await _loginService.ResetPasswordRequestAsync(request);

            if (result.IsFailed)
            {
                return Unauthorized(result.Errors[0]);
            }

            ISuccess success = result.Successes[0];

            return Ok(success);
        } 

        [HttpPost("/password-reset")]
        public async Task<IActionResult> ResetPassword(PasswordReset request)
        {
            Result result = await _loginService.ResetPasswordAsync(request);

            if (result.IsFailed)
            {
                return Unauthorized(result.Errors[0]);
            }

            ISuccess success = result.Successes[0];

            return Ok(success);
        }
    }
}
