using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Moment2MVC.Models;

namespace Moment2MVC.Controllers
{
    public class MainController : Controller
    {
        private static List<CatModel> cats = new List<CatModel>
        {
            new CatModel { Name = "Whiskers", Breed = "Siamese", Age = 2 },
            new CatModel { Name = "Mittens", Breed = "Maine Coon", Age = 3 },
            new CatModel { Name = "Shadow", Breed = "Persian", Age = 4 },
            new CatModel { Name = "Simba", Breed = "Bengal", Age = 1 },
            new CatModel { Name = "Luna", Breed = "Sphynx", Age = 5 }
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NumbersPage()
        {
            return View();
        }

        public IActionResult CatView()
        {
            var model = new CatListModel
            {
                CatList = cats.ToArray()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CatListModel model)
        {
            if (ModelState.IsValid)
            {
                var newCat = new CatModel
                {
                    Name = model.NewCat.Name,
                    Breed = model.NewCat.Breed,
                    Age = model.NewCat.Age
                };
                cats.Add(newCat);
                return RedirectToAction("CatView");
            }
            return View("CatView", new CatListModel { CatList = cats.ToArray(), NewCat = model.NewCat });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SelectOperation(string operation)
        {
            ViewBag.SelectedOperation = $"You selected: {operation}";
            return View("Index");
        }

        [HttpPost]
        public IActionResult ChooseNumber(int chosenNumber)
        {
            if (chosenNumber == 0)
            {
                ViewBag.ChosenNumber = "Choose a number";
            }
            else
            {
                ViewBag.ChosenNumber = $"You chose number: {chosenNumber}";
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult SelectOptions(bool option1, bool option2, bool option3)
        {
            ViewBag.SelectedOptions = $"You selected: " +
            $"{(option1 ? "Option 1 " : "")}" +
            $"{(option2 ? "Option 2 " : "")}" +
            $"{(option3 ? "Option 3 " : "")}" +
            $"{(option1 || option2 || option3 ? "" : "No Selected")}";
            return View("Index");
        }
    }
}