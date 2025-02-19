using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Moment2MVC.Models;

namespace Moment2MVC.Controllers
{
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private static List<CatModel> cats = new List<CatModel>
        {
            new CatModel { Name = "Whiskers", Breed = "Siamese", Age = 2 },
            new CatModel { Name = "Mittens", Breed = "Maine Coon", Age = 3 },
            new CatModel { Name = "Shadow", Breed = "Persian", Age = 4 },
            new CatModel { Name = "Simba", Breed = "Bengal", Age = 1 },
            new CatModel { Name = "Luna", Breed = "Sphynx", Age = 5 }
        };
        

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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
    }
}