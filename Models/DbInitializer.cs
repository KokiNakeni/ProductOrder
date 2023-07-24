using ProductOrder_application.Models;
using System;
using System.Linq;

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
                new StaffMemberDetails
                {
                    FirstName = "Carson",
                    Surname = "Alexander",
                    StreetAddress = "14 Panfluit Street",
                    Suburb = "Eco Park",
                    Town = "Pretoria",
                    PostalCode = "1620"
                },
                new StaffMemberDetails
                {
                    FirstName = "Koketso",
                    Surname = "Madumo",
                    StreetAddress = "14 Panfluit Street",
                    Suburb = "Eco Park",
                    Town = "Pretoria",
                    PostalCode = "1620"
                },
                new StaffMemberDetails
                {
                    FirstName = "Mabutho",
                    Surname = "Nakeni",
                    StreetAddress = "14 Panfluit Street",
                    Suburb = "Eco Park",
                    Town = "Pretoria",
                    PostalCode = "1620"
                },
                new StaffMemberDetails
                {
                    FirstName = "Moeti",
                    Surname = "Nakeni",
                    StreetAddress = "14 Panfluit Street",
                    Suburb = "Eco Park",
                    Town = "Pretoria",
                    PostalCode = "1620"
                }
            };

            foreach (var staffMember in staffMembers)
            {
                context.StaffMemberDetails.Add(staffMember);
            }

            context.SaveChanges();

            // Products
            //string imagePath = "C:\\Users\\Dell\\source\\repos\\ProductOrder application\\ProductOrder application\\Images\\laptopbags.jpg"; // Replace this with the actual path to your image file
            //byte[] imageBytes = File.ReadAllBytes(imagePath);

            {
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
                }



                }
            ;

                foreach (var product in products)
                {
                    context.Products.Add(product);
                }

                context.SaveChanges();

                // Orders
                var orders = new Order[]
                {
                new Order { OrderDate = DateTime.Now, StaffId = 1, TotalAmount = 3433.20m },
                new Order { OrderDate = DateTime.Now, StaffId = 2, TotalAmount = 3433.20m },
                new Order { OrderDate = DateTime.Now, StaffId = 3, TotalAmount = 3433.20m },
                new Order { OrderDate = DateTime.Now, StaffId = 4, TotalAmount = 3433.20m },
                };

                foreach (var order in orders)
                {
                    context.Orders.Add(order);
                }

                context.SaveChanges();

                // OrderItems
                var orderItems = new OrderItem[]
                {
                new OrderItem { OrderId = 1, ProductId = 1, Quantity = 1 },
                new OrderItem { OrderId = 2, ProductId = 2, Quantity = 1 },
                new OrderItem { OrderId = 3, ProductId = 3, Quantity = 1 },
                new OrderItem { OrderId = 4, ProductId = 4, Quantity = 1 }
                };

                foreach (var orderItem in orderItems)
                {
                    context.OrderItems.Add(orderItem);
                }

                context.SaveChanges();
            }
        }
    }
}
