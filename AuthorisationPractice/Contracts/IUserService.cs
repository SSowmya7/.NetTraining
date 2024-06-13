using AuthenticationPraction.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationPraction.Contracts
{
    public interface IUserService
    {
        public  String Login(User user);
    }
}
