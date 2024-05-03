using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure.Contexts;
using ProductService.Model.Entities;

namespace ProductService.Model.Services
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategories();

        void AddNeWCategory(AddCategoryDto category);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ProductDatabaseContext _dbContext;

        public CategoryService(ProductDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddNeWCategory(AddCategoryDto category)
        {
            Category categorys = new Category()
            {
                Description= category.Description,
                Name= category.Name,
            };
            _dbContext.Categorys.Add(categorys);
            _dbContext.SaveChanges();
        }

        public List<CategoryDto> GetCategories()
        {
           return _dbContext.Categorys.OrderBy(x=>x.Name).Select(x=>new CategoryDto
           {
               Description = x.Description,
               Name= x.Name,
               Id=x.Id,
           }).ToList();
        }
    }
    public class AddCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
