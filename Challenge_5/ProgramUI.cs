using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public class ProgramUI
    {
        EmailRepository _emailRepo = new EmailRepository();

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Please select an action:\n" +
                    "1. Create new customer\n" +
                    "2. Read List of Customers\n" +
                    "3. Update Customer Type\n" +
                    "4. Delete Customer");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        CreateCustomer();
                        break;
                    case 2:
                        CustomerList();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 3:
                        UpdateCustomer();
                        break;
                    case 4:
                        DeleteCustomer();
                        break;
                    default:
                        Console.WriteLine("Uhhh try again");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void CreateCustomer()
        {
            Customer newCustomer = new Customer();
            Console.WriteLine("Type of customer: \n" +
                "Please Choose Corresponding Number\n" +
                "1. Current\n" +
                "2. Potential\n" +
                "3. Past\n");
            var input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    newCustomer.UserType = CustomerType.Current;
                    break;
                case 2:
                    newCustomer.UserType = CustomerType.Potential;
                    break;
                case 3:
                    newCustomer.UserType = CustomerType.Past;
                    break;
                default:
                    break;
            }
            Console.WriteLine("What is the customer's first name?");
            newCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("What is the customer's last name?");
            newCustomer.LastName = Console.ReadLine();

            _emailRepo.AddCustomerToList(newCustomer);
        }

        private void CustomerList()
        {
            _emailRepo.GetCustomerList().Sort((x, y) => string.Compare(x.LastName, y.LastName));
            Console.WriteLine("The current list of customers are: ");
            int i = 0;
            foreach (Customer customer in _emailRepo.GetCustomerList())
            {
                i++;
                Console.WriteLine(i + "." +
                    $"\tCustomer Type: {customer.UserType}\n" +
                    $"\tFirst Name: {customer.FirstName}\n" +
                    $"\tLast Name: {customer.LastName}\n" +
                    $"\tEmail: {_emailRepo.SendEmailToCustomer(customer)}");
            }
        }

        private void UpdateCustomer()
        {
            CustomerList();
            Console.WriteLine("Please select the customer's number to update");
            int customerRemove = int.Parse(Console.ReadLine());
            var updateCustomer = _emailRepo.GetCustomerList()[customerRemove - 1];
            Console.WriteLine("What status would you like the customer to be updated to?" +
                    "Please Choose Corresponding Number\n" +
                    "1. Current\n" +
                    "2. Potential\n" +
                    "3. Past\n");
            var input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    updateCustomer.UserType = CustomerType.Current;
                    break;
                case 2:
                    updateCustomer.UserType = CustomerType.Potential;
                    break;
                case 3:
                    updateCustomer.UserType = CustomerType.Past;
                    break;
                default:
                    break;
            }

        }

        private void DeleteCustomer()
        {
            CustomerList();
            Console.WriteLine("Please choose the item number to be removed.");
            int customerRemove = int.Parse(Console.ReadLine());
            _emailRepo.GetCustomerList().RemoveAt(customerRemove - 1);
        }
    }
}
