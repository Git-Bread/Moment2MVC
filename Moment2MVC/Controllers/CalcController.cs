using Microsoft.AspNetCore.Mvc;
using Moment2MVC.Models;

namespace Moment2MVC.Controllers
{
    public class CalcController : Controller
    {
        [HttpGet]
        public IActionResult NumbersPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(int addNumber1, int addNumber2)
        {
            int result = addNumber1 + addNumber2;
            ViewBag.Result = $"The result of addition is: {result}";
            return View("NumbersPage");
        }

        [HttpPost]
        public IActionResult Subtract(int subtractNumber1, int subtractNumber2)
        {
            int result = subtractNumber1 - subtractNumber2;
            ViewData["Result"] = $"The result of subtraction is: {result}";
            return View("NumbersPage");
        }

        [HttpPost]
        public IActionResult Multiply(MultiplicationViewModel model)
        {
            model.Result = model.Number1 * model.Number2;
            return View("NumbersPage", model);
        }
    }
}
