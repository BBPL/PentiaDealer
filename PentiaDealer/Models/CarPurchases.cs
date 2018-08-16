using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PentiaDealer.Models
{
    public partial class CarPurchases
    {
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("CarID")]
        public int CarId { get; set; }
        [Column("SalesPersonID")]
        public int SalesPersonId { get; set; }
        public double PricePaid { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        public int Id { get; set; }

        [ForeignKey("CarId")]
        [InverseProperty("CarPurchases")]
        public Cars Car { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("CarPurchases")]
        public Customers Customer { get; set; }
        [ForeignKey("SalesPersonId")]
        [InverseProperty("CarPurchases")]
        public SalesPeople SalesPerson { get; set; }
    }
}
