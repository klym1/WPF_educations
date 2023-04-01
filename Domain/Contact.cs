using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using DAL;

namespace Domain
{
    [DebuggerDisplay("User: {Id} {FirstName} ({LastName})")]
    [Table("contact")]
    public class Contact : IWithId
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        public string LastName { get; set; }

        [Column("nickname")]
        public string Nickname { get; set; }

        [Column("company")]
        public string Company { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("deleted")]
        public bool Deleted { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Contact()
        {
            Orders = new List<Order>();
        }
    }
}
