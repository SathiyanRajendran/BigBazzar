using System.ComponentModel.DataAnnotations;

namespace BigBazzar.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Special Characters not allowed")]
        [Required(ErrorMessage ="AdminName is Required")]
        [Display(Name = "Admin Name")]

        public string AdminName { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "At least one uppercase, one lowercase, one digit, one special character and minimum eight in length")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [Display(Name = "Password")]

        public string AdminPassword { get; set; }
    }
}
