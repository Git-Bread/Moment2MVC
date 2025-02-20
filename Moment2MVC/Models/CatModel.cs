using System.ComponentModel.DataAnnotations;

namespace Moment2MVC.Models
{
    public class CatModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Breed is required")]
        [StringLength(50, ErrorMessage = "Breed cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Breed must only contain letters and spaces")]
        public string Breed { get; set; } = "";

        [Required(ErrorMessage = "Age is required")]
        [Range(0, 20, ErrorMessage = "Age must be between 0 and 20")]
        public int Age { get; set; }
    }
    public class CatListModel
    {
        public CatModel NewCat { get; set; } = new CatModel();
        public CatModel[] CatList { get; set; } = new CatModel[0];
    }
}