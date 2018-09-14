using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class GroceryOrder
    {
        public GroceryOrder()
        {
            this.GroceryOrderProducts = new HashSet<GroceryOrderProduct>();
        }

        public Guid ID { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string AptSuite { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
        public ICollection<GroceryOrderProduct> GroceryOrderProducts { get; set; }
        public DateTime? PaidDate { get; set; }
    }
}
