using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class GroceryOrderProduct
    {
        public Guid ID { get; set; }
        public GroceryOrder GroceryOrder { get; set; }
        public Guid GroceryOrderID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int? ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
