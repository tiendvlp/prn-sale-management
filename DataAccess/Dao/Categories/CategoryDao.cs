using System;
using DataAccess.Data;
using BusinessObject;

namespace DataAccess.Dao.Categories
{
    public class CategoryDao : Dao<Category>, ICategoryDao
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryDao(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
