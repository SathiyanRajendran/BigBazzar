using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBazzar.Models
{
    public class Traders
    {
        [Key]
        public int TraderId { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Special Characters not allowed")]

        public string? TraderName { get; set; }
        public string? TraderPhoneNumber { get; set; }
      
        public string? TraderEmail { get; set; }
        
        public string? Password { get; set; }
       
        public string? ConfirmPassword { get; set; }
        public virtual ICollection<Products>? Products { get; set; } 
    }
}
