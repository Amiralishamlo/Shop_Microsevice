namespace BasketService.Model.Entity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
