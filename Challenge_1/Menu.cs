using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class Menu
    {
        public decimal ItemPrice { get; set; }
        public string ItemTitle { get; set; }
        public string ItemDescription { get; set; }
        public List<string> IngredientList { get; set; }

        public Menu(decimal itemPrice, string itemTitle, string itemDescription, List<string> ingredientList)
        {
            ItemPrice = itemPrice;
            ItemTitle = itemTitle;
            ItemDescription = itemDescription;
            IngredientList = ingredientList;

        }

        public Menu()
        {
            
        }



    }
}
