using Microservice.Web.Frontend.Models.Dtos;

namespace Microservice.Web.Frontend.Servcies.BasketService
{
    public interface IBasketService
    {
        BasketDto GetBasket(string UserId);
        ResultDto AddToBasket(AddToBasketDto addToBasket, string UserId);
        ResultDto DeleteFromBasket(Guid Id);
        ResultDto UpdateQuantity(Guid BasketItemId, int quantity);
        ResultDto ApplyDiscountToBasket(Guid basketId, Guid discountId);

    }
}
