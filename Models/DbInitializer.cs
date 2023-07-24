using ProductOrder_application.Models;
using System;
using System.Linq;
using System.IO;

namespace ProductOrder_application.Models
{
    public class DbInitializer
    {
        public static void Initialize(ProductOrder_applicationContext context)
        {
            context.Database.EnsureCreated();

            if (context.StaffMemberDetails.Any())
            {
                return;
            }

            // StaffMemberDetails
            var staffMembers = new StaffMemberDetails[]
            {
                // ... Your existing staff members ...
            };

            foreach (var staffMember in staffMembers)
            {
                context.StaffMemberDetails.Add(staffMember);
            }

            context.SaveChanges();

            // Products
            string filePath = @"C:\Users\Dell\source\repos\ProductOrder application\ProductOrder application\Images\laptopbags.jpg";
            byte[] imageBytes = null;
            try
            {
                imageBytes = File.ReadAllBytes(filePath);
                Console.WriteLine("Successfully converted file to byte array.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            var products = new Product[]
            {
                new Product
                {
                    Id = 1,
                    ProductTitle = "Laptop bag",
                    Price = decimal.Parse("14000.00"),
                    Description = "Sleek laptop bag",
                    Image = imageBytes
                },
                new Product
                {
                    Id = 2,
                    ProductTitle = "Screens",
                    Price = decimal.Parse("5400.00"),
                    Description = "Sleek screen",
                    Image = imageBytes
                },
                new Product
                {
                    Id = 3,
                    ProductTitle = "LED Mouse",
                    Price = decimal.Parse("300.00"),
                    Description = "Colourful mouse",
                    Image = imageBytes
                },
                new Product
                {
                    Id = 4,
                    ProductTitle = "Keyboard",
                    Price = decimal.Parse("600.00"),
                    Description = "Colourful keyboard",
                    Image = imageBytes
                },
                new Product
                {
                    Id = 5,
                    ProductTitle = "Headphones",
                    Price = decimal.Parse("200.00"),
                    Description = "High-quality headphones",
                    Image = imageBytes
                },
                new Product
                {
                    Id = 6,
                    ProductTitle = "Desk Chair",
                    Price = decimal.Parse("1200.00"),
                    Description = "Ergonomic desk chair",
                    Image = imageBytes
                },
                new Product
                {
                    Id = 7,
                    ProductTitle = "Printer",
                    Price = decimal.Parse("4000.00"),
                    Description = "Fast and efficient printer",
                    Image = imageBytes
                },
                new Product
                {
                    Id = 8,
                    ProductTitle = "External Hard Drive",
                    Price = decimal.Parse("800.00"),
                    Description = "1TB external hard drive",
                    Image = imageBytes
                },
                new Product
                {
                    Id = 9,
                    ProductTitle = "Portable Bluetooth Speaker",
                    Price = decimal.Parse("350.00"),
                    Description = "Wireless speaker with great sound",
                    Image = imageBytes
                },
                new Product
                {
                    Id = 10,
                    ProductTitle = "Smartwatch",
                    Price = decimal.Parse("900.00"),
                    Description = "Fitness and health tracking smartwatch",
                    Image = imageBytes
                }
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();

            // Orders
            var orders = new Order[]
            {
                // ... Your existing orders ...
            };

            foreach (var order in orders)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();

            // OrderItems
            var orderItems = new OrderItem[]
            {
                // ... Your existing order items ...
            };

            foreach (var orderItem in orderItems)
            {
                context.OrderItems.Add(orderItem);
            }

            context.SaveChanges();
        }
    }
}
