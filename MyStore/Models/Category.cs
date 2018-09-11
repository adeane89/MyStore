using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class Category
    {
        public Category()
        {
            this.GroceryProduct = new HashSet<GroceryProducts>();
        }
        public string Name { get; set; }
        public ICollection<GroceryProducts> GroceryProduct { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
