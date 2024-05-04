using BasketService.Model.Dtos;

namespace BasketService.Model.Services.DiscountServices
{
    public interface IDiscountService
    {
        DiscountDto GetDiscountById(Guid id);
        ResultDto<DiscountDto> GetDiscountByCode(string Code);
    }
}
