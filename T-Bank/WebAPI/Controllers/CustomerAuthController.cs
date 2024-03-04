using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAuthController : Controller
    {
        //Login, Register
        IAuthService<Customer> _customerAuthService;

        public CustomerAuthController(IAuthService<Customer> authService)
        {
            _customerAuthService = authService;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _customerAuthService.Login(userForLoginDto);

            if (!userToLogin.Success)
            {
                return BadRequest();
            }


            var result = _customerAuthService.CreateAccessToken(userToLogin.Data);
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
            var userExist = _customerAuthService.UserExists(userForRegisterDto.Email);
            
            if (!userExist.Success)
                return BadRequest();

            var registerResult = _customerAuthService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _customerAuthService.CreateAccessToken(registerResult.Data);

            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
    }
}
