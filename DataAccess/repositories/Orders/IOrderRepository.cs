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
        void Update(string id1, string id2, DateTime orderDate, DateTime requiredDate, DateTime shippedDate, double freight);
        void RemoveOrderContainsNoOrderDetails();
    }
}
