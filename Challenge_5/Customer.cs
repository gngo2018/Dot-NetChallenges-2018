using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public enum CustomerType {Current, Potential, Past}
    public class Customer
    {
        public CustomerType UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(CustomerType userType, string firstName, string lastName)
        {
            UserType = userType;
            FirstName = firstName;
            LastName = lastName;
        }

        public Customer()
        {

        }
    }
}
