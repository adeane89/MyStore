using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class GroceryCart
    {
        public GroceryCart()
        {
            this.GroceryCartProducts = new HashSet<GroceryCartProducts>();
        }
        public GroceryProducts GroceryProducts { get; set; }
        public int ID { get; set; }
        public ICollection<GroceryCartProducts> GroceryCartProducts { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
