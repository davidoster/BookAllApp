using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAllApp.Models
{
    public class Order
    {
        public string OrderID { get; set; }
        public string BookID { get; set; }
        public string CustomerID { get; set; }
    }
}
