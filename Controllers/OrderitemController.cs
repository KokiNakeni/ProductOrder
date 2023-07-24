using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrder_application.Models;

namespace ProductOrder_application.Controllers
{
    public class OrderitemController : Controller
    {
        private readonly ProductOrder_applicationContext _context;

        public object OrderItems { get; private set; }

        public OrderitemController(ProductOrder_applicationContext context)
        {
            _context = context;
        }

        // GET: /Cart
        public IActionResult Index()
        {
            var cartItems = GetCartItems();
            return View(cartItems);
        }

        // GET: /Cart/AddToCart/1
        public IActionResult AddToCart(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var cartItems = GetCartItems();
            cartItems.Add(new OrderItem { Product = product, Quantity = 1 });

            SaveCartItems(cartItems);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Cart/RemoveFromCart/1
        public IActionResult RemoveFromCart(int id)
        {
            var OrderItem = GetCartItems();
            var OrderItem = OrderItems.FirstOrDefault(item => item.Product.Id == id);

            if (OrderItem != null)
            {
                OrderItem.Remove(OrderItem);
                SaveCartItems(OrderItem);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Cart/ClearCart
        public IActionResult ClearCart()
        {
            SaveCartItems(new List<OrderItem>());
            return RedirectToAction(nameof(Index));
        }

        private List<OrderItem> GetCartItems()
        {
            var cartItems = HttpContext.Session.Get<List<OrderItem>>("CartItems");
            return cartItems ?? new List<OrderItem>();
        }

        private void SaveCartItems(List<OrderItem> cartItems)
        {
            HttpContext.Session.Set("OrderItem", OrderItem);
        }
    }
}
