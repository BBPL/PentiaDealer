using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PentiaDealer.Models
{
    public partial class Customers
    {
        public Customers()
        {
            CarPurchases = new HashSet<CarPurchases>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Column(TypeName = "date")]
        public DateTime Created { get; set; }
        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }

        [InverseProperty("Customer")]
        public ICollection<CarPurchases> CarPurchases { get; set; }
    }
}
