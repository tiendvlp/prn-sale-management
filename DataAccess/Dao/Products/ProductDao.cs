using System;
using DataAccess.Data;
using BusinessObject;
using System.Linq;

namespace DataAccess.Dao.Products
{
    public class ProductDao : Dao<Product>, IProductDao
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductDao(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Product> GetWithFilters(string id, string name, int unitMax, int unitMin, double priceMax, double priceMin)
        {
            IQueryable<Product> result = from product in _dbContext.Products select product;

            if (!String.IsNullOrWhiteSpace(name))
            {
                result = from product in result where product.Name.ToLower().Contains(name.ToLower()) select product;
            }
            if (!String.IsNullOrWhiteSpace(id))
            {
                result = from product in result where product.Id == id select product;
            }

            if (unitMax >= 0)
            {
                result = from product in result where product.Quantity <= unitMax select product;
            }

            if (unitMin >= 0)
            {
                result = from product in result where product.Quantity >= unitMin select product;
            }

            if (priceMax >= 0)
            {
                result = from product in result where product.Price <= priceMax select product;
            }

            if (priceMin >= 0)
            {
                result = from product in result where product.Price >= priceMin select product;
            }

            return result;
        }
    }
}
