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
        public Double Price { get; set; }
        public string Unit { get; private set; }
        public void setWeightUnit (WeightUnit value )  { 
            Unit = value.ToString();
        }
        public long Quantity { get; set; }

        public Product()
        {
        }

        public Product(String id, string categoryId, string name, double weight, WeightUnit unit, long quantity, double price)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Weight = weight;
            Unit = Enum.GetName(unit);
            Quantity = quantity;
            Price = price;
        }

        public Product(string id, Category category, string name, double weight, WeightUnit unit, long quantity, double price)
        {
            Id = id;
            CategoryId = category.Id;
            Category = category;
            Name = name;
            Weight = weight;
            Unit = Enum.GetName(unit);
            Quantity = quantity;
            Price = price;
        }
    }
}
