using System;
using System.Globalization;
using OrderItemsEx.Entities.Enums;
using System.Collections.Generic;
using System.Text;

namespace OrderItemsEx.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Orders { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem order)
        {
            Orders.Add(order);
        }

        public void RemoveItem(OrderItem order)
        {
            Orders.Remove(order);
        }

        public double Total()
        {
            var sum = 0.0;
            
            foreach(OrderItem order in Orders)
            {
                sum += order.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items: ");
            foreach(OrderItem o in Orders)
            {
                sb.AppendLine(o.Product.Name + ", $" + o.Price.ToString("F2", CultureInfo.InvariantCulture) + ", Quantity: " + o.Quantity + ", Subtotal: $" + o.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
