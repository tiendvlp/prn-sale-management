using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject;
using DataAccess.Dao.Categories;
using DataAccess.Dao.Products;
using DataAccess.UnitOfWork;

namespace DataAccess.repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private IProductDao _productDao;

        public ProductRepository(IProductDao productDao)
        {
            _productDao = productDao;
        }


        public Product Add(string categoryId, string name, double weight, string unit, long quantity, double price)
        {
            string uuid = System.Guid.NewGuid().ToString().Substring(0, 8);
            Product newProduct = new Product(uuid, categoryId, name, weight, unit, quantity, price);
            _productDao.Add(newProduct);
            return newProduct;
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
