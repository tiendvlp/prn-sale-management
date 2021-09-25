using System;
namespace BusinessObject
{
    public class Category
    {
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
