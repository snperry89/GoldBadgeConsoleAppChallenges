using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repository
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        // list of ingredients
        public double Price { get; set; }
        public string[,] Ingredients { get; set; }




        public MenuItem() { }
        public MenuItem(int mealNumber, string mealName, string description, double price, string[,] ingredients)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Price = price;
            Ingredients = ingredients;
        }
    }
}
