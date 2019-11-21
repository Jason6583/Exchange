using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Auth.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService _identityServerInteractionService;
        public HomeController(IIdentityServerInteractionService identityServerInteractionService)
        {
            _identityServerInteractionService = identityServerInteractionService;
        }

        public async Task<IActionResult> Error(string errorId)
        {
            var context = await _identityServerInteractionService.GetErrorContextAsync(errorId);
            return View(context);
        }
    }
}