using AutoMapper;
using BasketService.Model.Entity;
using BasketService.Model.Services;

namespace BasketService.Infrastructure.Mapping
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {
            CreateMap<BasketItem, AddItemToBasketDto>().ReverseMap();
        }
    }
}