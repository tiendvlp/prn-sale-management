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
        private ICategoryDao _categoryDao;

        public ProductRepository(IProductDao productDao, ICategoryDao categoryDao)
        {
            _categoryDao = categoryDao;
            _productDao = productDao;
        }


        public Product Add(string categoryId, string name, double weight, WeightUnit unit, long quantity, double price)
        {
            string uuid = System.Guid.NewGuid().ToString().Substring(0, 8);
            Product newProduct = new Product(uuid, categoryId, name, weight, unit, quantity, price);
            _productDao.Add(newProduct);
            return newProduct;
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> result =  _productDao.GetAll().ToList();

            return result;
        }

        public Product GetById(string id)
        {
            return _productDao.Get(id); 
        }

        public IEnumerable<Product> GetWIthFilter(string id, string name, int unitMax, int unitMin, double priceMax, double priceMin)
        {
            IQueryable<Product> result = _productDao.GetWithFilters(id, name, unitMax, unitMin, priceMax, priceMin);
            return result.ToList();
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

        public Product Update(Product product)
        {
            Product updatedProduct = _productDao.Get(product.Id);
            Category newCategory = _categoryDao.Get(product.CategoryId);

            if (updatedProduct == null)
            {
                return null;
            }
            updatedProduct.Name = product.Name;
            updatedProduct.SetCategory(newCategory);
            updatedProduct.Price = product.Price;
            updatedProduct.Quantity = product.Quantity;
            updatedProduct.Weight = product.Weight;
            updatedProduct.setWeightUnit(product.GetWeightUnitInEnum());
            return updatedProduct;
        }
    }
}
