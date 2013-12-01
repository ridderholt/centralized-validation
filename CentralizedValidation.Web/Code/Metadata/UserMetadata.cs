using System.ComponentModel.DataAnnotations;

namespace CentralizedValidation.Web.Code.Metadata
{
    public class UserMetadata
    {
        [Display(Name = "Firstname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Firstname is required")]
        public string Firstname { get; set; }

        [Display(Name = "Lastname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }
    }
}