using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using DAL;

namespace Domain
{
    [DebuggerDisplay("Order: {Id} {Date.ToShortDateString()} ({Discount.ToString(\"C2\")})")]
    [Table("contact_order")]
    public class Order : IWithId
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Required]
        [Column("order_date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("discount")]
        public decimal Discount { get; set; }

        public virtual Contact Contact { get; set; }

        [Required]
        [Column("contact_id")]
        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}