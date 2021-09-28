using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Product : Entity
    {
        [ForeignKey("Category")]
        public String CategoryId { get; private set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; private set; }
        public String Name { get; set; }
        public Double Weight { get; set; }
        public Double Price { get; set; }
        public string Unit { get; private set; }

        public void SetCategory (Category category)
        {
            CategoryId = category.Id;
            Category = category;
        }

        public void setWeightUnit (WeightUnit value )  { 
            Unit = value.ToString();
        }

        public WeightUnit GetWeightUnitInEnum ()
        {
            if (Unit.Equals("KILOGRAM"))
            {
                return WeightUnit.KILOGRAM;
            }
            if (Unit.Equals("TON"))
            {
                return WeightUnit.TON;
            }
            if (Unit.Equals("MILLIGRAM"))
            {
                return WeightUnit.MILLIGRAM;
            }
            if (Unit.Equals("GRAM"))
            {
                return WeightUnit.GRAM;
            }
            throw new Exception("Your weight unit is invalid");

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
