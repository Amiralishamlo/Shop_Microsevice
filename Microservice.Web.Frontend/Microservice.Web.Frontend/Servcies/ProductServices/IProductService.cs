namespace Microservice.Web.Frontend.Servcies.ProductServices
{
    public interface IProductService
	{
		IEnumerable<ProductDto> GetAllProduct();
		ProductDto Getproduct(Guid Id);

    }
}
