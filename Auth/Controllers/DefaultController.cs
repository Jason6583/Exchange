using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}