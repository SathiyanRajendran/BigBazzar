﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBazzar.Models
{
    public class OrderMasters
    {
        [Key]
        public int OrderMasterId { get; set; }
        public int? OrderDate { get; set; }
        public int? Total { get; set; }
        public string? CardNumber { get; set; }
        public float? AmountPaid { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customers? Customers { get; set; }
        public virtual ICollection<OrderDetails>? OrderDetails { get; set; }

    }
}