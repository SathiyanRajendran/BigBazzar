using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBazzar.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Products? Products { get; set; }

        public float? ProductRate { get; set; }
        public float? ProductQuantity { get; set; }
        public int? OrderMasterId { get; set; }
        [ForeignKey("OrderMasterId")]
        public virtual OrderMasters? OrderMasters { get; set; }
    
    }
}
