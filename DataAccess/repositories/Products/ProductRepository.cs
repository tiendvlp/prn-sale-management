using System;
using BusinessObject;
using DataAccess.Dao.Products;
using DataAccess.UnitOfWork;

namespace DataAccess.repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private ProductDao _productDao;

        public ProductRepository(ProductDao productDao)
        {
            _productDao = productDao;
        }
    }
}
