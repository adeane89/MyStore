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
    public class GroceryProductController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public GroceryProductController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index(string category)
        {
            if (await _context.GroceryProduct.CountAsync() == 0)
            {
                List<GroceryProducts> Produce = new List<GroceryProducts>();
                Produce.Add(new GroceryProducts { Name = "Tomato", ImagePath = "./images/tomato.jpg", Description = "Red", Price = 20.99m, DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                _context.Categories.Add(new Category { Name = "Produce", GroceryProduct = Produce });

                List<GroceryProducts> Meat = new List<GroceryProducts>();
                Meat.Add(new GroceryProducts { Name = "Ground Beef", ImagePath = "./images/tomato.jpg", Description = "Beef", Price = 19.99m, DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                _context.Categories.Add(new Category { Name = "Meat", GroceryProduct = Meat });

                List<GroceryProducts> Seafood = new List<GroceryProducts>();
                Seafood.Add(new GroceryProducts { Name = "Seafood", ImagePath = "./images/tomato.jpg", Description = "Shrimp", Price = 18.99m, DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                _context.Categories.Add(new Category { Name = "Seafood", GroceryProduct = Seafood });

                await _context.SaveChangesAsync();
            }

            ViewBag.selectedCategory = category;
            List<GroceryProducts> model;
            if (string.IsNullOrEmpty(category))
            {
                model = await this._context.GroceryProduct.ToListAsync();
            }
            else
            {
                model = await this._context.GroceryProduct.Where(x => x.CategoryName == category).ToListAsync();
            }

            ViewData["Categories"] = await this._context.Categories.Select(x => x.Name).ToArrayAsync();

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            GroceryProducts model = await _context.GroceryProduct.FindAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(int? id, int quantity, string category, string name, decimal price)
        {
            GroceryCart cart = null;
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                cart = await _context.GroceryCart.Include(x => x.GroceryCartProducts).FirstOrDefaultAsync(x => x.ApplicationUserID == currentUser.Id);
                if (cart == null)
                {
                    cart = new GroceryCart();
                    cart.ApplicationUserID = currentUser.Id;
                    cart.DateCreated = DateTime.Now;
                    cart.DateLastModified = DateTime.Now;
                    _context.GroceryCart.Add(cart);
                }
            }
            else
            {
                if (Request.Cookies.ContainsKey("cart_id"))
                {
                    int existingCartID = int.Parse(Request.Cookies["cart_id"]);
                    cart = await _context.GroceryCart.Include(x => x.GroceryCartProducts).FirstOrDefaultAsync(x => x.ID == existingCartID);
                }

                if (cart == null)
                {
                    cart = new GroceryCart
                    {
                        DateCreated = DateTime.Now,
                        DateLastModified = DateTime.Now
                    };

                    _context.GroceryCart.Add(cart);
                }
            }

            GroceryCartProducts product = cart.GroceryCartProducts.FirstOrDefault(x => x.GroceryProductID == id);
            if (product == null)
            {
                product = new GroceryCartProducts
                {
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                    GroceryProductID = id ?? 0,
                    Quantity = 0,
                    Name = name,
                    Price = price
                };

                cart.GroceryCartProducts.Add(product);
            }
            product.Quantity += quantity;
            product.DateLastModified = DateTime.Now;
            product.Name = name;
            product.Price = price;

            await _context.SaveChangesAsync();


            if (!User.Identity.IsAuthenticated)
            {
                Response.Cookies.Append("cart_id", cart.ID.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTime.Now.AddYears(1)
                });
            }
            return RedirectToAction("Index", "GroceryCart");
        }
    }
}