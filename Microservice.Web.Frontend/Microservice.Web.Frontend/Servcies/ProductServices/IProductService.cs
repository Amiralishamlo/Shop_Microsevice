using RestSharp;
using System.Text.Json;

namespace Microservice.Web.Frontend.Servcies.ProductServices
{
	public interface IProductService
	{
		IEnumerable<ProductDto> GetAllProduct();
		ProductDto Getproduct(Guid Id);

    }

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
            var request = new RestRequest($"/api/Product/{Id}", Method.Get);

            var response = restClient.Execute(request);

            var product = JsonSerializer.Deserialize<ProductDto>(response.Content);
            return product;
        }
    }



	public class ProductCategory
	{
		public string categoryId { get; set; }
		public string category { get; set; }
	}
	public class ProductDto
	{
		public string id { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public object image { get; set; }
		public int price { get; set; }
		public ProductCategory productCategory { get; set; }
	}
}
