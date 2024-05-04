namespace OrderService.Model.Services.OrderServices
{
    public interface IOrderService
    {
        List<OrderDto> GetOrdersForUser(string UserId);
        OrderDetailDto GetOrderById(Guid Id);
    }
}
