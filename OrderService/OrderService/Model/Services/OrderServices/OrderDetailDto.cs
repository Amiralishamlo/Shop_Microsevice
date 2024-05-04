namespace OrderService.Model.Services.OrderServices
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime OrderPlaced { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool OrderPaid { get;  set; }
        public List<OrderLineDto> OrderLines { get; set; }
    }
}
