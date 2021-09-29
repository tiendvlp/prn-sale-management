using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject;
using DataAccess.Dao.Categories;
using DataAccess.Dao.Products;
using DataAccess.UnitOfWork;

namespace DataAccess.repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ICategoryDao _categoryDao;

        public CategoryRepository(ICategoryDao categoryDao)
        {
            _categoryDao = categoryDao;
        }


        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> result = _categoryDao.GetAll();

            return result.ToList();
        }

        public Category GetById(string id)
        {
            return _categoryDao.Get(id); 
        }

        public Category RemoveById(string id)
        {
            var removedProduct = _categoryDao.Get(id);
            _categoryDao.Remove(removedProduct);
            return removedProduct;
        }
    }
}
