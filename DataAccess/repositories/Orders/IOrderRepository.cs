using System;
using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.repositories.Orders
{
    public interface IOrderRepository
    {
        public Order Add( string memberId, DateTime orderDate, DateTime requiredDate, DateTime shippedDate, double freight);
        List<Order> GetWithFilter(DateTime startDate, DateTime endDate);
        void RemoveById(string id);
    }
}
