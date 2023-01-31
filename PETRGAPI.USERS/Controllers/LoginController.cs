using FluentResults;
using Microsoft.AspNetCore.Mvc;


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
        public IActionResult LoginUser(LoginRequest request)
        {
            Result result = _loginService.UserLog(request);
            if (result.IsFailed)
            {
                IError error = result.Errors[0];
                return Unauthorized(error);
            }
            ISuccess success = result.Successes[0];


            return Ok(success);
        }
    }
}
