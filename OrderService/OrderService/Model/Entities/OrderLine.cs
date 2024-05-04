namespace OrderService.Model.Entities
{
    public class OrderLine
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; } 
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }


}
