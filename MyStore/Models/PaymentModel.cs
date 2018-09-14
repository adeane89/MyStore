using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class PaymentModel
    {
        public GroceryOrder Order { get; set; }
        public Guid ID { get; set; }
        [Required]
        public string Nonce { get; set; }
    }
}
