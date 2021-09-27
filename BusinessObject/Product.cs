using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Product
    {
        [Key]
        public String Id { get; set; }
        public String CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public String Name { get; set; }
        public Double Weight { get; set; }
        public String Unit { get; set; }
        public long Quantity { get; set; }

        public Product()
        {
        }

        public Product(String id, string categoryId, string name, double weight, string unit , long quantity)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Weight = weight;
            Unit = unit;
            Quantity = quantity;
        }

        public Product(string id, Category category, string name, double weight, string unit, long quantity)
        {
            Id = id;
            CategoryId = category.Id;
            Category = category;
            Name = name;
            Weight = weight;
            Unit = unit;
            Quantity = quantity;
        }
    }
}
