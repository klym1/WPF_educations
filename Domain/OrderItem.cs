using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using DAL;

namespace Domain
{
    [DebuggerDisplay("Order: {Id} {ItemName} {ItemPrice} x{Quantity} ")]
    [Table("contact_order_item")]
    public class OrderItem : IWithId
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("item_name")]
        public string ItemName { get; set; }

        [Required]
        [Column("item_price")]
        public decimal ItemPrice { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        [Column("contact_order_id")]
        [ForeignKey("Order")]
        public int ContactOrderId { get; set; }
    }
}