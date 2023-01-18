using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UsersAPI.Services;

namespace UsersAPI.Controllers
{
    [Route("[controller]")]
    public class LogoutController : Controller
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        public IActionResult LogoutUser(){
            Result result = _logoutService.LogoutUser();
            if(result.IsFailed) return Unauthorized();
            
            return Ok();

        }


    }
}