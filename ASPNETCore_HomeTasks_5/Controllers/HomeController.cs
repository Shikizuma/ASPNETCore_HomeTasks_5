using ASPNETCore_HomeTasks_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace ASPNETCore_HomeTasks_5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static int UsersOnline = 0;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
    
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("HasIncremented") == null)
            {
                Interlocked.Increment(ref UsersOnline);
                HttpContext.Session.SetString("HasIncremented", "true");
            }
            ViewBag.UserCount = UsersOnline;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}