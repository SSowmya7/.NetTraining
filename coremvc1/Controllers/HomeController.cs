using coremvc1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace coremvc1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }





        public string GetMessage()
        {
            return "Hello Welcome";

        }

        public ContentResult ShowMessage()
        {
            return Content("Hello Welcome");
        }

        public ViewResult ShowData()  {
        
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
