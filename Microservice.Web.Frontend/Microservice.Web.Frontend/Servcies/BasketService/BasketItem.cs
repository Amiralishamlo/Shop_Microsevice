namespace Microservice.Web.Frontend.Servcies.BasketService
{
    public class BasketItem
    {
        public string id { get; set; }
        public string productId { get; set; }
        public string productName { get; set; }
        public int unitPrice { get; set; }
        public int quantity { get; set; }
        public string imageUrl { get; set; }

        public int TotalPrice()
        {
            return unitPrice * quantity;
        }
    }
}
