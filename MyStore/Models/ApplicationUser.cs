using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyStore.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
            this.GroceryCart = new GroceryCart();
        }

        public ApplicationUser(string userName) : base(userName)
        {
            this.GroceryCart = new GroceryCart();
        }

        public GroceryCart GroceryCart { get; set; }
        public int GroceryCartID { get; set; }
    }
}
