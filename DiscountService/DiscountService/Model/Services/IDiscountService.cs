using AutoMapper;
using DiscountService.Infrastructure.Contexts;
using DiscountService.Model.Entitty;

namespace DiscountService.Model.Services
{
    public interface IDiscountService
    {
        DiscountDto GetDiscountByCode(string Code);
        DiscountDto GetDiscountById(Guid Id);
        bool UseDiscount(Guid Id);
        bool AddNewDiscount(string Code, int Amount);
    }

    public class DiscountService : IDiscountService
    {
        private readonly DiscountDataBaseContext context;
        private readonly IMapper mapper;

        public DiscountService(DiscountDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool AddNewDiscount(string Code, int Amount)
        {
            DiscountCode discountCode = new DiscountCode()
            {
                Amount = Amount,
                Code = Code,
                Used = false,
            };
            context.DiscountCodes.Add(discountCode);
            context.SaveChanges();
            return true;
        }

        public DiscountDto GetDiscountByCode(string Code)
        {
            var discountCode = context.DiscountCodes.SingleOrDefault(p => p.Code.Equals(Code));

            if (discountCode == null)
                return null;
            var result = mapper.Map<DiscountDto>(discountCode);
            return result;
        }
        public DiscountDto GetDiscountById(Guid Id)
        {
            var discountCode = context.DiscountCodes.SingleOrDefault(p => p.Id==Id);

            if (discountCode == null)
                return null;
            var result = mapper.Map<DiscountDto>(discountCode);
            return result;
        }

        public bool UseDiscount(Guid Id)
        {
            var discountCode = context.DiscountCodes.Find(Id);
            if (discountCode == null)
                throw new Exception("Discouint Not Found....");
            discountCode.Used = true;
            context.SaveChanges();
            return true;
        }
    }

    public class DiscountDto
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public string Code { get; set; }
        public bool Used { get; set; }
    }
}
