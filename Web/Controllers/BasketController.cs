using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
    }
}
