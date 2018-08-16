using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PentiaDealer.Models
{
    public partial class SalesPeople
    {
        public SalesPeople()
        {
            CarPurchases = new HashSet<CarPurchases>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }
        [Required]
        public string Address { get; set; }
        public double Salary { get; set; }
        [Key]
        [Column("SalesPersonID")]
        public int SalesPersonId { get; set; }

        [InverseProperty("SalesPerson")]
        public ICollection<CarPurchases> CarPurchases { get; set; }
    }
}
