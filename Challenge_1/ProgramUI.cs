using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class ProgramUI
    {
        MenuRepository _menuRepo = new MenuRepository();
        

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Please choose an action: \n" +
                    "1. Add Menu Item\n" +
                    "2. Delete Menu Item\n" +
                    "3. See Current Menu Items\n" +
                    "4. Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        CreateMenuItem();
                        break;
                    case 2:
                        DeleteItem();
                        break;
                    case 3:
                        SeeCurrentMenu();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Try again please");
                        Console.ReadKey();
                        break;
                }
            }
            Console.WriteLine("Have a great day!");
        }

        private void CreateMenuItem()
        {
            Menu newMenuItem = new Menu();
            Console.WriteLine("What price would you want the item to be?(No $ needed)");
            newMenuItem.ItemPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("What title would you like to use for the menu item?");
            newMenuItem.ItemTitle = Console.ReadLine();
            Console.WriteLine("What description would you give the menu item?");
            newMenuItem.ItemDescription = Console.ReadLine();
            newMenuItem.IngredientList = AddIngredient();

            _menuRepo.AddItemToList(newMenuItem);

        }

        private List<string> AddIngredient()
        {
            var ingredientsList = new List<string>();
            Console.WriteLine("Would you like to add ingredients to the menu item? (y/n)");
            string answer = Console.ReadLine();
            while (answer.Contains("y"))
            {
                Console.WriteLine("What ingredient would you like to add?");
                string ingredient = Console.ReadLine();
                ingredientsList.Add(ingredient);

                Console.WriteLine("Would you like to include more ingredients? (y/n)");
                answer = Console.ReadLine();
            }
            return ingredientsList;
        }

        private string PrintOutIngredients(List<string> ingredients)
        {
            string printedIngredients = "";
            foreach(string ingredient in ingredients)
            {
                printedIngredients = ingredient + ", " + printedIngredients; 
            }

            return printedIngredients;
        }

        private void DeleteItem()
        {
            SeeCurrentMenu();
            Console.WriteLine("Please choose the listed item number to remove.");
            string menuItemRemoveString = Console.ReadLine();
            int menuItemRemove = int.Parse(menuItemRemoveString);
            _menuRepo.GetMenuList().RemoveAt(menuItemRemove - 1);

        }

        private void SeeCurrentMenu()
        {
            Console.WriteLine("The current list of menu items registered are: ");
            int i = 0;
            foreach (Menu item in _menuRepo.GetMenuList())
            {
                i++;
                Console.WriteLine(i + ".\t" +
                    $"Menu Item Name: {item.ItemTitle}\n\t" +
                    $"Price: ${item.ItemPrice}\n\t" +
                    $"Description: {item.ItemDescription}\n\t" +
                    $"Ingredients: {PrintOutIngredients(item.IngredientList)}\t");
            }
        }
     }
}
