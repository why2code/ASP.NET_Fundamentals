using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (user != null)
            {
                return RedirectToAction("All", "Book");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}