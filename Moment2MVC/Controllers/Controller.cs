using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Moment2MVC.Models;

namespace Moment2MVC.Controllers
{
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<Controller> _logger;

        public Controller(ILogger<Controller> logger)
        {
            _logger = logger;
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
