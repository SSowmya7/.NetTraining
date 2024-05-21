using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthenticationPraction.Models;
using AuthenticationPraction.Services;
using Microsoft.AspNetCore.Identity.Data;
using AuthenticationPraction.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationPraction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;
        public PrjContext context;
        public LoginController(UserService userService , PrjContext prjContext)
        {
            _userService = userService;
            context = prjContext;
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
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var users = await context.Users.ToListAsync();
            return Ok(users);
        }
    }
}
