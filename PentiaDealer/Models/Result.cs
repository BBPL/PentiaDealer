using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PentiaDealer.Models
{
    public class Result
    {
        public Customers Customers { get; set; }
        public Cars Cars { get; set; }
        public SalesPeople SalesPerson{ get; set; }
        public DateTime BuyDate{ get; set; }
        public double Price { get; set; }

    }
}
