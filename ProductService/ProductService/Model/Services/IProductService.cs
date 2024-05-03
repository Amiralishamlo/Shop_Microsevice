using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure.Contexts;
using ProductService.Model.Entities;

namespace ProductService.Model.Services
{
    public interface IProductService
    {
        List<ProductDto> GetAll();

        ProductDto GetProductBy(Guid id);

        void AddProduct(AddProductDto addProduct);
          
    }
    public class ProductServices : IProductService
    {
        private readonly ProductDatabaseContext _databaseContext;

        public ProductServices (ProductDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddProduct(AddProductDto addProduct)
        {
            var category=_databaseContext.Categorys.Find(addProduct.CategoryId);
            if (category == null)
                throw new Exception("Category notfound ...");

            Product product = new Product()
            {
                Image = addProduct.Image,
                Name = addProduct.Name,
                Price = addProduct.Price,
                Description = addProduct.Description,
                Category=category,
            };
            _databaseContext.Products.Add(product);
            _databaseContext.SaveChanges();
        }

        public List<ProductDto> GetAll()
        {
            return _databaseContext.Products.OrderByDescending(x => x.Id).Include(x=>x.Category).Select(x => new ProductDto
            {
                Description = x.Description,
                Name = x.Name,
                Id = x.Id,
                Image= x.Image,
                Price = x.Price,
                Category=new ProductCategoryDto
                {
                    Category=x.Category.Name,
                    CategoryId=x.Category.Id,
                }
            }).ToList();
        }

        public ProductDto GetProductBy(Guid id)
        {
            var product= _databaseContext.Products.Where(x=>x.Id==id).Include(x => x.Category).Select(x => new ProductDto
            {
                Description = x.Description,
                Name = x.Name,
                Id = x.Id,
                Image = x.Image,
                Price = x.Price,
                Category = new ProductCategoryDto
                {
                    Category = x.Category.Name,
                    CategoryId = x.Category.Id,
                }
            }).SingleOrDefault();
            if (product == null)
                throw new Exception("Product Not Found ....");
            return product;
        }
    }
    public class AddProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }

    }
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public ProductCategoryDto Category { get; set; }
    }
    public class ProductCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Category { get; set; }
    }
}
