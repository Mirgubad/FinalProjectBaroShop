using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class FavouriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
