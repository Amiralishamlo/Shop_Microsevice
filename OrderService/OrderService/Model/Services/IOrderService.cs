using Microsoft.EntityFrameworkCore;
using OrderService.Infrastructure.Context;
using OrderService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Model.Services
{
    public interface IOrderService
    {
        void AddOrder(AddOrderDto addOrder);
        List<OrderDto> GetOrdersForUser(string UserId);
        OrderDto GetOrderById(Guid Id);
    }


    public class OrderService : IOrderService
    {
        private readonly OrderDataBaseContext context;

        public OrderService(OrderDataBaseContext context)
        {
            this.context = context;
        }
        public void AddOrder(AddOrderDto addOrder)
        {
            List<OrderLine> orderLines = new List<OrderLine>();
            foreach (var item in addOrder.OrderLines)
            {
                orderLines.Add(new OrderLine
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductPrice = item.ProductPrice,
                    Quantity = item.Quantity,
                });
                Order order = new Order(addOrder.UserId, orderLines);
                context.Orders.Add(order);
                context.SaveChanges();

            }
        }

        public OrderDto GetOrderById(Guid Id)
        {
            var orders = context.Orders.
             Include(p => p.OrderLines)
             .FirstOrDefault(p => p.Id == Id);

            if (orders == null)
                throw new Exception("Order Not Found");

            var result = new OrderDto
            {
                Id = orders.Id,
                OrderPaid = orders.OrderPaid,
                OrderPlaced = orders.OrderPlaced,
                UserId = orders.UserId,
                OrderLines = orders.OrderLines.Select(o => new OrderLineDto
                {
                    Id = o.Id,
                    ProductId = o.ProductId,
                    ProductName = o.ProductName,
                    ProductPrice = o.ProductPrice,
                    Quantity = o.Quantity,
                }).ToList(),
            };
            return result;
        }

        public List<OrderDto> GetOrdersForUser(string UserId)
        {
            var orders = context.Orders.
              Include(p => p.OrderLines)
             .Where(p => p.UserId == UserId)
             .Select(p => new OrderDto
             {
                 Id = p.Id,
                 OrderPaid = p.OrderPaid,
                 OrderPlaced = p.OrderPlaced,
                 UserId = p.UserId,
                 OrderLines = p.OrderLines.Select(o => new OrderLineDto
                 {
                     Id = o.Id,
                     ProductId = o.ProductId,
                     ProductName = o.ProductName,
                     ProductPrice = o.ProductPrice,
                     Quantity = o.Quantity,
                 }).ToList(),
             }).ToList();
            return orders;
        }
    }

    public class AddOrderDto
    {
        public string UserId { get; set; }
        public List<AddOrderLineDto> OrderLines { get; set; }

    }
    public class AddOrderLineDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public bool OrderPaid { get; set; }
        public DateTime OrderPlaced { get; set; }
        public List<OrderLineDto> OrderLines { get; set; }

    }
    public class OrderLineDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
