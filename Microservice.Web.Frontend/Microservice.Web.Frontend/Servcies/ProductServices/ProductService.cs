using RestSharp;
using System.Text.Json;

namespace Microservice.Web.Frontend.Servcies.ProductServices
{
    public class ProductService : IProductService
	{
		private RestClient restClient;
		public ProductService(RestClient restClient)
		{
			this.restClient = restClient;
		}

		public  IEnumerable<ProductDto> GetAllProduct()
		{
			var request = new RestRequest("api/Product", Method.Get);
			request.AlwaysMultipartFormData = true;
			RestResponse response = restClient.Execute(request);
			var result=JsonSerializer.Deserialize<List<ProductDto>>(response.Content);
			return result;
		}
        public ProductDto Getproduct(Guid Id)
        {
            var request = new RestRequest($"/api/Product/Id?id={Id}", Method.Get);

            RestResponse response = restClient.Execute(request);

            var product = JsonSerializer.Deserialize<ProductDto>(response.Content);
            return product;
        }
    }
}
