using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class Category : Entity
    {
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
