using System;
using BusinessObject;

namespace DataAccess.repositories.Orders
{
    public interface IOrderRepository
    {
        public Order Add( string memberId, DateTime orderDate, DateTime requiredDate, DateTime shippedDate, double freight);
    }
}
