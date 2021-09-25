using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Product
    {
        [Key]
        public String Id { get; set; }
        [ForeignKey("Category")]
        public String CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public String Name { get; set; }
        public Double Weight { get; set; }
        public String Unit { get; set; }
        public String City { get; set; }
        public long Quantity { get; set; }

        public Product()
        {
        }

        public Product(String id, string categoryId, string name, double weight, string unit, string city, long quantity)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Weight = weight;
            Unit = unit;
            City = city;
            Quantity = quantity;
        }
    }
}
