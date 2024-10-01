using Microsoft.AspNetCore.Mvc;

namespace miniStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Category()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
