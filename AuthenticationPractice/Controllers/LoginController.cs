using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthenticationPraction.Models;
using AuthenticationPraction.Services;
using Microsoft.AspNetCore.Identity.Data;

namespace AuthenticationPraction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(User user)
        {
            
            if (_userService.ValidateUser(user))
            {

                var Token = _userService.Login(user);
                return Ok(Token);
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }

        }
    }
}
