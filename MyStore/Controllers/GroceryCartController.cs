using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Models;

namespace MyStore.Controllers
{
    public class GroceryCartController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        public GroceryCartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            GroceryCart model = null;
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = _userManager.GetUserAsync(User).Result;
                model = await _context.GroceryCart.Include(x => x.GroceryCartProducts).ThenInclude(x => x.GroceryProduct).FirstOrDefaultAsync(x => x.ApplicationUserID == currentUser.Id);
            }

            else if (Request.Cookies.ContainsKey("cart_id"))
            {
                int existingCartID = int.Parse(Request.Cookies["cart_id"]);
                model = await _context.GroceryCart.Include(x => x.GroceryCartProducts).ThenInclude(x => x.GroceryProduct).FirstOrDefaultAsync(x => x.ID == existingCartID);
                //model = await _context.GroceryCart.Include(x => x.GroceryCartProducts).ThenInclude(x => x.GroceryProducts).FirstOrDefaultAsync(x => x.ID == existingCartID);
            }

            else
            {
                model = new GroceryCart();
            }

            return View(model);
        }

        //public async Task<IActionResult> Remove(int id)
        //{
        //    GroceryCart cart = null;
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var currentUser = await _userManager.GetUserAsync(User);
        //        cart = await _context.GroceryCart.Include(x => x.GroceryCartProducts).FirstOrDefaultAsync(x => x.ApplicationUserID == currentUser.Id);
        //    }

        //    else
        //    {
        //        if (Request.Cookies.ContainsKey("cart_id"))
        //        {
        //            int existingCartID = int.Parse(Request.Cookies["cart_id"]);
        //            cart = await _context.GroceryCart.Include(x => x.GroceryCartProducts).FirstOrDefaultAsync(x => x.ID == existingCartID);
        //            cart.DateLastModified = DateTime.Now;
        //        }
        //    }

        //    GroceryCartProducts product = cart.GroceryCartProducts.FirstOrDefault(x => x.ID == id);
        //    cart.GroceryCartProducts.Remove(product);
        //    await _context.SaveChangesAsync();
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        Response.Cookies.Append("cart_id", cart.ID.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
        //        {
        //            Expires = DateTime.Now.AddYears(1)
        //        });
        //    }
        //    return RedirectToAction("Index", "Cart");

        //}
    }
}