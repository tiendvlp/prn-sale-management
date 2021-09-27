﻿using System;
using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.repositories.Products
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(String id);
        public Product Add ( string categoryId, string name, double weight, string unit, long quantity, double price);
        public Product RemoveById(String id);
        public Product RemoveProduct(Product product);
    }
}
