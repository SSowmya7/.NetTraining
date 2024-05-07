using Microsoft.AspNetCore.Mvc;

namespace coremvc1.Controllers
{
    public class AboutController: Controller
    {
        public ContentResult ShowContent()
        {
            return Content("New Controller");
        }
    }
}
