using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PentiaDealer.Models
{
    public partial class Cars
    {
        public Cars()
        {
            CarPurchases = new HashSet<CarPurchases>();
        }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        [Required]
        [StringLength(50)]
        public string Color { get; set; }
        [Required]
        [StringLength(50)]
        public string Extras { get; set; }
        public double RecommendedPrice { get; set; }
        [Key]
        [Column("CarID")]
        public int CarId { get; set; }

        [InverseProperty("Car")]
        public ICollection<CarPurchases> CarPurchases { get; set; }
    }
}
