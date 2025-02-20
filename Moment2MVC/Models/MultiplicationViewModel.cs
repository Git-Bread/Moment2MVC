using System.ComponentModel.DataAnnotations;

namespace Moment2MVC.Models
{
    public class MultiplicationViewModel
    {
        [Required(ErrorMessage = "Number is required")]
        public int Number1 { get; set; }
        [Required(ErrorMessage = "Number is required")]
        public int Number2 { get; set; }
        public int? Result { get; set; }
    }
}