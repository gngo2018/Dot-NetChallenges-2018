using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    class EmailRepository
    {
        List<Customer> _listOfCustomers = new List<Customer>();

        public void AddCustomerToList(Customer customer)
        {
            _listOfCustomers.Add(customer);
        }

        public List<Customer> GetCustomerList()
        {
            return _listOfCustomers;
        }

        public string SendEmailToCustomer(Customer customer)
        {
            string emailResponse = "";
            switch (customer.UserType)
            {
                case CustomerType.Current:
                    emailResponse = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon!";
                        break;
                case CustomerType.Past:
                    emailResponse = "It's been a long time since we've heard from you, we want you back!";
                    break;
                case CustomerType.Potential:
                    emailResponse = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
                default:
                    break;
            }
            return emailResponse;
        }
    }
}
