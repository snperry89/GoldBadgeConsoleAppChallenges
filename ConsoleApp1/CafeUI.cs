using _01_Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItem_Console
{
    class CafeUI
    {
        private MenuRepository _repo = new MenuRepository();
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option:\n" +
                    "1. Create new menu item\n" +
                    "2. Update existing menu item\n" +
                    "3. Delete existing menu item\n" +
                    "4. View all menu items\n" +
                    "5. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        UpdateExistingMenuItem();
                        break;
                    case "3":
                        DeleteExistingMenuItem();
                        break;
                    case "4":
                        ViewAllMenuItems();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;
                }
                Console.WriteLine("Please press any key to continue:");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItem newMenuItem = new MenuItem();
            Console.WriteLine("What is the number for this menu item?");
            newMenuItem.MealNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is the name for this menu item?");
            newMenuItem.MealName = Console.ReadLine();
            Console.WriteLine("What is the description for this menu item?");
            newMenuItem.Description = Console.ReadLine();
            Console.WriteLine("What is the price of this menu item?");
            newMenuItem.Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("What are the ingredients in this menu item?" );
            //newMenuItem.Ingredients = (Console.ReadLine());
        }

        private void UpdateExistingMenuItem()
        {
            Console.Clear();
            ViewAllMenuItems();

            Console.WriteLine("Enter the name of the menu item you would like to update:");
            string oldMenuItemName = Console.ReadLine();
            MenuItem newMenuItem = new MenuItem();

            Console.WriteLine("What is the new name for this item?");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("What is the new number for this item?");
            string mealNumberAsString = Console.ReadLine();
            int mealNumberAsInt = Convert.ToInt32(mealNumberAsString);
            newMenuItem.MealNumber = mealNumberAsInt;

            Console.WriteLine("What is the new description for this item?");
            newMenuItem.Description = Console.ReadLine();

            Console.WriteLine("What is the new price for this item?");
            string priceAsString = Console.ReadLine();
            double priceAsDouble = Convert.ToDouble(priceAsString);
            newMenuItem.Price = priceAsDouble;

            
        }
       
        private void DeleteExistingMenuItem()
        {
            Console.Clear();
            ViewAllMenuItems();

            Console.WriteLine("Enter the name of the menu item you would like to delete:");

            bool wasDeleted = _repo.DeleteExistingMenuItem(Console.ReadLine());

            if (wasDeleted)
            {
                Console.WriteLine("The menu item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The menu item could not be deleted.");
            }

        }
        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> allMenuItems = _repo.GetMenuItems();
            foreach (MenuItem item in allMenuItems)
            {
                Console.WriteLine($"Menu Item: {item.MealName}" );
            }
        }

    }
}
