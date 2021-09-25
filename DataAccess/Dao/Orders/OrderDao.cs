using System;
using DataAccess.Data;
using BusinessObject;

namespace DataAccess.Dao.Orders
{
    public class OrderDao : Dao<Order>, IOrderDao
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderDao(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
