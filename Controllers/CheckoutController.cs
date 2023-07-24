using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrder_application.Models;

namespace ProductOrder_application.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ProductOrder_applicationContext _context;

        public CheckoutController(ProductOrder_applicationContext context)
        {
            _context = context;
        }

        // GET: /Checkout
        public IActionResult Index()
        {
            var OrderItems = GetOrderItem();
            return View(OrderItem);
        }

        // POST: /Checkout/PlaceOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrder(Order model)
        {
            if (ModelState.IsValid)
            {
                var caOrderItem = GetOrderItem();

                if (OrderItem.Count == 0)
                {
                    ModelState.AddModelError("", "Your cart is empty. Please add items to proceed.");
                    return RedirectToAction(nameof(Index));
                }

                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    StaffId = model.StaffId, // Replace with the currently logged-in staff's ID or any appropriate method to obtain it
                    TotalAmount = OrderItem.Sum(item => item.Product.Price * item.Quantity)
                };

                // Save the order to the database and generate order items
                // (Assuming you have already defined the OrderItem class and have the necessary logic to save to the database)

                // Clear the cart after placing the order
                SaveCartItems(new List<OrderItem>());

                return RedirectToAction("Index", "Home"); // Redirect to a confirmation page or any other appropriate page
            }

            // If the model state is not valid, return to the checkout page with validation errors
            return View("Index", model);
        }

        private List<OrderItem> OrderItem()
        {
            var cartItems = HttpContext.Session.Get<List<OrderItem>>("CartItems");
            return cartItems ?? new List<OrderItem>();
        }

        private void SaveCartItems(List<OrderItem> OrderItem)
        {
            HttpContext.Session.Set("OrderItem", OrderItem);
        }
    }
}
