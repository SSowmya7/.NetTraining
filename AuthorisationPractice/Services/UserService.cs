using AuthenticationPraction.Contracts;
using AuthenticationPraction.Data;
using AuthenticationPraction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationPraction.Services
{
    public class UserService:IUserService
    {
        private readonly IConfiguration _configuration;
        public PrjContext context;
        public UserService(IConfiguration configuration,PrjContext PrjContext) // DI
        {
            _configuration = configuration;
            context = PrjContext;
        }

        public bool ValidateUser(User LoginUser) {
            var user = context.Users.SingleOrDefault(u => u.UserName == LoginUser.UserName);
            if (user != null && user.UserName == LoginUser.UserName && user.Password == LoginUser.Password)
            {
                return true;
            }
            return false;
        }
        public  String Login(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWTSECRET:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }
    }
}
