using System;
using System.Collections.Generic;
using System.Text;
using Order.Entities.Enums;
using System.Globalization;

namespace Order.Entities {
    class Order {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() {
        }

        public Order(DateTime moment, OrderStatus status, Client client) {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item) {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item) {
            Items.Remove(item);
        }

        public double Total() {
            double ttl = 0;
            foreach (OrderItem item in Items) {
                ttl += item.SubTotal();
            }
            return ttl;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine("Order moment: " + DateTime.Now);
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client.Name + " (" + Client.BirthDate.ToString("dd/MM/yyyy") + ") - " + Client.Email);
            sb.AppendLine("Order items:");

            foreach (OrderItem item in Items) {
                sb.AppendLine(item.Product.Name + ", Quantity: " + item.Quantity + ", Subtotal: $" + item.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }

            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
