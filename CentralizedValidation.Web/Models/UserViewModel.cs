using System.ComponentModel.DataAnnotations;

namespace CentralizedValidation.Web.Models
{
    public class UserViewModel
    {
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }
    }
}