using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class Category
    {
        [Key]
        public String Id { get; set; }
        public String Name { get; set; }

        public Category()
        {

        }

        public Category(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
