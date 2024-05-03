namespace Microservice.Web.Frontend.Servcies.BasketService
{
    public class BasketDto
    {
        public string id { get; set; }
        public string userId { get; set; }
        public Guid? discountId { get; set; }
        public DiscountInBasketDto DiscountDetail { get; set; } = null;

        public List<BasketItem> items { get; set; }
        public int TotalPrice()
        {
            int result = items.Sum(p => p.unitPrice * p.quantity);
            if (discountId.HasValue)
                result = result - DiscountDetail.Amount;
            return result;
        }
    }
}
