using BasketService.Model.Dtos;
using DiscountService.Proto;
using Grpc.Net.Client;
using System.Threading.Channels;

namespace BasketService.Model.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly GrpcChannel _grpcChannel;
        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            string Server = configuration["MicroServiceAddress:DiscountService:url"];
            _grpcChannel = GrpcChannel.ForAddress(Server);
        }

        public ResultDto<DiscountDto> GetDiscountByCode(string Code)
        {
            var grpc_discountService = new
              DiscountServiceProto.DiscountServiceProtoClient(_grpcChannel);
            var result = grpc_discountService.GetDiscountByCode(new RequestGetDiscountByCode
            {
                Code = Code,
            });


            if (result.IsSuccess)
            {
                return new ResultDto<DiscountDto>
                {
                    Data = new DiscountDto
                    {
                        Amount = result.Data.Amount,
                        Code = result.Data.Code,
                        Id = Guid.Parse(result.Data.Id),
                        Used = result.Data.Used
                    },
                    IsSuccess = result.IsSuccess,
                    Message = result.Message,
                };
            }
            return new ResultDto<DiscountDto>
            {
                IsSuccess = false,
                Message = result.Message,
            };
        }

        public DiscountDto GetDiscountById(Guid id)
        {
            var grpc_discountService = new DiscountServiceProto.DiscountServiceProtoClient(_grpcChannel);
            var result = grpc_discountService.GetDiscountById(new RequestGetDiscountById
            {
                Id = id.ToString(),
            });

            if (result.IsSuccess)
            {
                return new DiscountDto
                {
                    Amount = result.Data.Amount,
                    Code = result.Data.Code,
                    Id = Guid.Parse(result.Data.Id),
                    Used = result.Data.Used
                };
            }
            return null;
        }
    }
}
