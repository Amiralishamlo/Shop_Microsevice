using AutoMapper;
using DiscountService.Model.Entitty;
using DiscountService.Model.Services;

namespace DiscountService.Infrastructure.Mapping
{
    public class DiscountMappingProfile : Profile
    {
        public DiscountMappingProfile()
        {
            CreateMap<DiscountCode, DiscountDto>().ReverseMap();

        }
    }
}
