using Microsoft.EntityFrameworkCore;
using OrderService.Infrastructure.Context;
using OrderService.Model.Entities;

namespace OrderService.Model.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly OrderDataBaseContext context;

        public OrderService(OrderDataBaseContext context)
        {
            this.context = context;
        }

        public OrderDetailDto GetOrderById(Guid Id)
        {
            var order=context.Orders.Include(x=>x.OrderLines)
                .ThenInclude(x=>x.Product)
                .FirstOrDefault(x=>x.Id==Id);

            if (order == null)
                throw new Exception("Order Not Found");

            var result = new OrderDetailDto()
            {
                Id = order.Id,
                Address = order.Address,
                FirstName = order.FirstName,
                LastName = order.LastName,
                PhoneNumber = order.PhoneNumber,
                OrderPlaced = order.OrderPlaced,
                UserId = order.UserId,
                OrderPaid = order.OrderPaid,
                OrderLines = order.OrderLines.Select(x => new OrderLineDto
                {
                    Id = x.Id,
                    Name = x.Product.Name,
                    Price = x.Product.Price,
                    Quantity = x.Product.Quantity,
                }).ToList(),
            };
            return result;
        }

        public List<OrderDto> GetOrdersForUser(string UserId)
        {
            var order = context.Orders.Include(x => x.OrderLines)
                .Where(x => x.UserId == UserId).Select(x=>new OrderDto
                {
                    Id=x.Id,
                    OrderPaid=x.OrderPaid,
                    TotalPrice=x.TotlaPrice,
                    OrderPlaced=x.OrderPlaced,
                    ItemCount=x.OrderLines.Count,
                }).ToList();
            return order;
        }
    }
}
