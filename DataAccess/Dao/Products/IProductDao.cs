using System;
using System.Linq;
using BusinessObject;

namespace DataAccess.Dao.Products
{
    public interface IProductDao : IDao<Product>
    {
        public IQueryable<Product> GetWithFilters(string id, string name, int unitMax, int unitMin, double priceMax, double priceMin);
    }
}
