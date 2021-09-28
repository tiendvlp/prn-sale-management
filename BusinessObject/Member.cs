using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Member : Entity
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String CompanyName { get; set; }

        public Member()
        {

        }

        public Member(string country, string city, string password, string email, string name, string id)
        {
            Country = country;
            City = city;
            Password = password;
            Email = email;
            Name = name;
            Id = id;
        }
    }
}
