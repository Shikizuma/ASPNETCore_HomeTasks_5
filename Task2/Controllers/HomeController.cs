using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task2.Models;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string cookieKey = "mydata";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DataModel model)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = model.DateTime;
            Response.Cookies.Append(cookieKey, model.Value, options);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Test()
        {
            string value = Request.Cookies[cookieKey];
            return View(value as object);
        }
    }
}