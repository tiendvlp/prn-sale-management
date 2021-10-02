using System;
using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.repositories.Products
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();

        public IEnumerable<Product> GetWIthFilter(string id, string name, int unitMax, int unitMin, double priceMax, double priceMin);
        public Product GetById(String id);
        public Product Add ( string categoryId, string name, double weight, WeightUnit unit, long quantity, double price);
        public Product RemoveById(String id);
        public Product Update(Product product);
        public Product RemoveProduct(Product product);
    }
}
