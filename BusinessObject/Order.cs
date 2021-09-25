using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Order
    {
        [Key]
        public String Id { get; set; }
        [ForeignKey("Member")]
        public String MemberId { get; set; }
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
