using Microservice.Web.Frontend.Models.Dtos;
using RestSharp;
using System.Text.Json;

namespace Microservice.Web.Frontend.Servcies.BasketService
{
    public class BasketService : IBasketService
    {
        private readonly RestClient restClient;

        public BasketService(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public ResultDto AddToBasket(AddToBasketDto addToBasket, string UserId)
        {
            var request = new RestRequest($"/api/Basket?UserId={UserId}", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            string serializeModel = JsonSerializer.Serialize(addToBasket);
            request.AddParameter("application/json", serializeModel, ParameterType.RequestBody);
            var response = restClient.Execute(request);
            return GetResponseStatusCode(response);
        }

        private static ResultDto GetResponseStatusCode(RestResponse response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new ResultDto
                {
                    IsSuccess = true,
                    Message= "success"
                };
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = response.ErrorMessage
                };
            }
        }

        public BasketDto GetBasket(string UserId)
        {
            var request = new RestRequest($"/api/Basket?UserId={UserId}", Method.Get);
            var response = restClient.Execute(request);
            var basket = JsonSerializer.Deserialize<BasketDto>(response.Content);
            return basket;
        }

        public ResultDto DeleteFromBasket(Guid Id)
        {
            var request = new RestRequest($"/api/Basket?ItemId={Id}", Method.Delete);
            var response = restClient.Execute(request);
            return GetResponseStatusCode(response);
        }

        public ResultDto UpdateQuantity(Guid BasketItemId, int quantity)
        {
            var request = new RestRequest($"/api/Basket?basketItemId={BasketItemId}&quantity={quantity}", Method.Put);
            var response = restClient.Execute(request);
            return GetResponseStatusCode(response);
        }

        public ResultDto ApplyDiscountToBasket(Guid basketId, Guid discountId)
        {

            var request = new RestRequest($"/api/Basket/{basketId}/{discountId}", Method.Put);
            var response = restClient.Execute(request);
            return GetResponseStatusCode(response);

        }
    }
}
