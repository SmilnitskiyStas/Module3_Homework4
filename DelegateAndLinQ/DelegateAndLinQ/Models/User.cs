using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndLinQ.Models
{
    internal class User
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public User(string name, string listName, string phoneNumber)
        {
            Name = name;
            LastName = listName;
            PhoneNumber = phoneNumber;
        }
    }
}
