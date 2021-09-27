using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> result =  _productDao.GetAll();

            return result;
        }

        public Product GetById(string id)
        {
            return _productDao.Get(id); 
        }

        public Product RemoveById(string id)
        {
            var removedProduct = _productDao.Get(id);
            _productDao.Remove(removedProduct);
            return removedProduct;
        }

        public Product RemoveProduct(Product product)
        {
            _productDao.Remove(product);
            return product;
        }
    }
}
