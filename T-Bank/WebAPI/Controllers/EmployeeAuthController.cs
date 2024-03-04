using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAuthController : Controller
    {
        //Login, Register
        IAuthService<Employee> _employeeAuthService;

        public EmployeeAuthController(IAuthService<Employee> authService)
        {
            _employeeAuthService = authService;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _employeeAuthService.Login(userForLoginDto);

            if (!userToLogin.Success)
            {
                return BadRequest();
            }


            var result = _employeeAuthService.CreateAccessToken(userToLogin.Data);
            return result.Success == true ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost("register")]
        public IActionResult Register(CustomerForRegisterDto userForRegisterDto)
        {
            var userExist = _employeeAuthService.UserExists(userForRegisterDto.Email);

            if (!userExist.Success)
                return BadRequest();

            var registerResult = _employeeAuthService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _employeeAuthService.CreateAccessToken(registerResult.Data);

            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
    }
}
