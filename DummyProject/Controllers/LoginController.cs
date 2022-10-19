using DummyProject.Models;
using DummyProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DummyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _loginService;

        public LoginController(ILogin loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginDTO userDTO)
        {
            var result = _loginService.Login(userDTO);
            if (result != null)
                return Ok(result);
            return BadRequest("Invalid username or password");
        }
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(LoginPassDTO user)
        {
            var result = _loginService.Register(user);
            if (result != null)
                return Ok(result);
            return BadRequest("Could not register user");
        }

    }
}

