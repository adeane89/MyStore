using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Models;
using MyStore.Services;
using Braintree;

namespace MyStore.Controllers
{
    public class CheckoutController : Controller
    {
        //inject
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        private IEmailSender _emailSender;
        private IBraintreeGateway _braintreeGateway;
        //SmartyStreets API called it "Client"

        public CheckoutController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender, IBraintreeGateway braintreeGateway)
        {
            _userManager = userManager;
            _context = context;
            _emailSender = emailSender;
            _braintreeGateway = braintreeGateway;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            CheckoutModel model = new CheckoutModel();
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                model.Email = currentUser.Email;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CheckoutModel model)
        {
            if (ModelState.IsValid)
            {
                GroceryOrder order = new GroceryOrder
                {
                    City = model.City,
                    State = model.State,
                    Email = model.Email,
                    StreetAddress = model.StreetAddress,
                    AptSuite = model.AptSuite,
                    ZipCode = model.ZipCode,
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                    PaidDate = (DateTime?)null
                };

                GroceryCart cart = null;
                if (User.Identity.IsAuthenticated)
                {
                    var currentUser = _userManager.GetUserAsync(User).Result;
                    cart = _context.GroceryCart.Include(x => x.GroceryCartProducts).ThenInclude(x => x.GroceryProduct).Single(x => x.ApplicationUserID == currentUser.Id);
                }
                else if (Request.Cookies.ContainsKey("cart_id"))
                {
                    int existingCartID = int.Parse(Request.Cookies["cart_id"]);
                    cart = _context.GroceryCart.Include(x => x.GroceryCartProducts).ThenInclude(x => x.GroceryProduct).FirstOrDefault(x => x.ID == existingCartID);
                }
                foreach (var cartItem in cart.GroceryCartProducts)
                {
                    order.GroceryOrderProducts.Add(new GroceryOrderProduct
                    {
                        DateCreated = DateTime.Now,
                        DateLastModified = DateTime.Now,
                        Quantity = cartItem.Quantity ?? 1,
                        ProductID = cartItem.GroceryProductID,
                        ProductDescription = cartItem.GroceryProduct.Description,
                        ProductName = cartItem.GroceryProduct.Name,
                        ProductPrice = cartItem.GroceryProduct.Price
                    });
                }

                _context.GroceryCartProducts.RemoveRange(cart.GroceryCartProducts);

                if (Request.Cookies.ContainsKey("cart_id"))
                {
                    Response.Cookies.Delete("cart_id");
                }

                _context.GroceryOrders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Payment", new { id = order.ID });
            }
            return View();
        }

        //public async Task<IActionResult> Payment(Guid id)
        //{
        //    PaymentModel model = new PaymentModel();
        //    model.ID = id;
        //    model.Order = await _context.GroceryOrders.Include(x => x.WineOrderProducts).FirstOrDefaultAsync(x => x.ID == id);
        //    ViewBag.ClientAuthorization = await _braintreeGateway.ClientToken.GenerateAsync();
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Payment(PaymentModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.Order = await _context.GroceryOrders.Include(x => x.GroceryOrderProducts).FirstOrDefaultAsync(x => x.ID == model.ID);
        //        var result = await _braintreeGateway.Transaction.SaleAsync(new TransactionRequest
        //        {
        //            Amount = model.Order.WineOrderProducts.Sum(x => x.Quantity * x.ProductPrice),
        //            PaymentMethodNonce = model.Nonce,
        //            LineItems = model.Order.WineOrderProducts.Select(x => new TransactionLineItemRequest
        //            {
        //                Description = x.ProductDescription,
        //                Name = x.ProductName,
        //                Quantity = x.Quantity,
        //                ProductCode = x.ProductID.Value.ToString(),
        //                UnitAmount = x.ProductPrice,
        //                TotalAmount = x.ProductPrice * x.Quantity,
        //                LineItemKind = TransactionLineItemKind.DEBIT
        //            }).ToArray()
        //        });
        //        await _emailSender.SendEmailAsync(model.Order.Email, "Your order " + model.ID, "Thanks for ordering! You bought : " + String.Join(",", model.Order.WineOrderProducts.Select(x => x.ProductName)));
        //        model.Order.PaidDate = DateTime.Now;
        //        await _context.SaveChangesAsync();
        //        //TODO: Save this information to the database so we can ship the order
        //        return RedirectToAction("Index", "Receipt", new { id = model.ID });
        //    }
        //    return View(model);

        //}
    }
}