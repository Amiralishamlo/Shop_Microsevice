﻿using DiscountService.Model.Services;
using DiscountService.Proto;
using Grpc.Core;

namespace DiscountService.GRPC
{
    public class GRPCDiscountService : DiscountServiceProto.DiscountServiceProtoBase
    {
        private readonly IDiscountService discountService;

        public GRPCDiscountService(IDiscountService discountService)
        {
            this.discountService = discountService;
        }
        public override Task<ResultGetDiscountByCode> GetDiscountByCode(RequestGetDiscountByCode request, ServerCallContext context)
        {
            var data = discountService.GetDiscountByCode(request.Code);
            return Task.FromResult(new ResultGetDiscountByCode
            {
                Amount = data.Amount,
                Code = data.Code,
                Id = data.Id.ToString(),
                Used = data.Used,
            });
        }

        public override Task<ResultUseDiscount> UseDiscount(RequestUseDiscount request, ServerCallContext context)
        {
            var result = discountService.UseDiscount(Guid.Parse(request.Id));
            return Task.FromResult(new ResultUseDiscount
            {
                IsSuccess = result,
            });

        }

        public override Task<ResultAddNewDiscount> AddNewDiscount(RequestAddNewDiscount request, ServerCallContext context)
        {
            var result = discountService.AddNewDiscount(request.Code, request.Amount);
            return Task.FromResult(new ResultAddNewDiscount
            {
                IsSuccess = result,
            });
        }
    }
}