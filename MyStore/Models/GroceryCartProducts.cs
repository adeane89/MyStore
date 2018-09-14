using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class GroceryCartProducts
    {
        public int ID { get; set; }
        public GroceryCart GroceryCart { get; set; }
        public int GroceryCartID { get; set; }

        public GroceryProducts GroceryProduct { get; set; }
        public int GroceryCartProductsID { get; set; }

        public int GroceryProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
