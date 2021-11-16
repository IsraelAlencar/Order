using System;
using Order.Entities;
using Order.Entities.Enums;
using System.Globalization;
using System.Collections.Generic;

namespace Order {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter client data:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);
            Order.Entities.Order order = new Order.Entities.Order(DateTime.Now, status, client);

            for (int i = 1; i <= n; i++) {
                Console.WriteLine($"Enter #{i} data:");

                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                Console.Write("Quantity: ");
                int quant = int.Parse(Console.ReadLine());

                Product product = new Product(productName, price);
                OrderItem item = new OrderItem(quant, price, product);
                order.AddItem(item);
            }

            Console.WriteLine(order);
        }
    }
}
