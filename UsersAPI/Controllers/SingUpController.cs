using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Dto;
using UsersAPI.Data.Requests;
using UsersAPI.Services;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SingUpController : Controller
    {
        SingUpService _singUpService;
        public SingUpController(SingUpService singUpService)
        {
            _singUpService = singUpService;
        }

        [HttpPost]
        public IActionResult SingUpUser(CreateUserDto createDto){
            var result = _singUpService.SingUpUser(createDto);
            if(result.Result.IsFailed) return StatusCode(500);

            var emailToken = result.Result.Successes[0];
            

            return Ok(emailToken);
        }
        [HttpPost("/active")]
        public IActionResult activeteAccountRequest(ActiveAccountRequest request){
            Result result = _singUpService.AccountActivation(request);
            if (result.IsFailed) return StatusCode(500);

            return Ok(result.Successes);
        }

    }
}
