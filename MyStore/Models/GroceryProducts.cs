using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class GroceryProducts
    {
        public GroceryProducts()
        {
            this.GroceryCartProducts = new HashSet<GroceryCartProducts>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }
        public Category Category { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
        public ICollection<GroceryCartProducts> GroceryCartProducts { get; set; }
    }
}
