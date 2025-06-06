using Microsoft.EntityFrameworkCore;
using ShoppyWeb.Data;
using ShoppyWeb.Models.Repositories.IRepository;
using System.ComponentModel.Design;

namespace ShoppyWeb.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
        public List<Product> GetAll()
        {
            List<Product> products = _dbContext.Product.ToList();
            return products;
        }
        public Product GetById(Guid id) { 
            return _dbContext.Product.Include("ProductCatagory")
                    .Include(p => p.ProductImages)
                    .FirstOrDefault(c => c.Id == id);
        }
    }
}
