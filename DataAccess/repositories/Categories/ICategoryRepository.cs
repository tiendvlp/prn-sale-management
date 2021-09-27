using System;
using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.repositories.Categories
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAll();
        public Category GetById(String id);
        public Category RemoveById(String id);
    }
}
