using System;
using DataAccess.Data;
using BusinessObject;

namespace DataAccess.Dao.Products
{
    public class ProductDao : Dao<Product>, IProductDao
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductDao(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
