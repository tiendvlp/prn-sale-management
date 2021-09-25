using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class OrderDetail
    {
        [Key]
        public String Id { get; set; }
        [ForeignKey("Order")]
        public String OrderId { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("Product")]
        public String ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }


        public OrderDetail()
        {

        }

        public OrderDetail(string id, string orderId, string productId, double unitPrice, int quantity, float discount)
        {
            Id = id;
            UnitPrice = unitPrice;
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
            Discount = discount;
        }
    }
}
