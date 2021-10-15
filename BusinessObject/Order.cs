using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Order : Entity
    {
        [ForeignKey("Member")]
        public String MemberId { get; set; }
        [ForeignKey("MemberId")]
        public virtual Member Member { get;  set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public Double Freight { get; set; }

        public Order()
        {
        }

        public Order(string id, string memberId, DateTime orderDate, DateTime requiredDate, DateTime shippedDate, double freight)
        {
            Id = id;
            MemberId = memberId;
            OrderDate = orderDate;
            RequiredDate = requiredDate;
            ShippedDate = shippedDate;
            Freight = freight;
        }
    }
}
