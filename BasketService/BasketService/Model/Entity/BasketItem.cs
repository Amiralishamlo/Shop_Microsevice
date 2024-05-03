namespace BasketService.Model.Entity
{
    public class BasketItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }

        public Basket Basket { get; set; }
        public Guid BasketId { get; set; }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
