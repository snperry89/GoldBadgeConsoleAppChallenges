using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repository
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menuItems = new List<MenuItem>();
        public bool AddItemToMenu(MenuItem newMenuItem)
        {
            int startingCount = _menuItems.Count;
            _menuItems.Add(newMenuItem);
            bool wasAdded = (_menuItems.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<MenuItem> GetMenuItems()
        {
            return _menuItems;
        }
        public MenuItem GetMenuItemByName(string MealName)
        {
            foreach (MenuItem menuItem in _menuItems)
            {
                if (menuItem.MealName.ToLower() == MealName.ToLower())
                {
                    return menuItem;
                }
            }
            return null;
        }
        public bool UpdateMenuItem(string originalMenuItem, MenuItem newMenuItemValues)
        {
            MenuItem oldMenuItem = GetMenuItemByName(originalMenuItem);
            if (oldMenuItem != null)
            {
                oldMenuItem.MealNumber = newMenuItemValues.MealNumber;
                oldMenuItem.MealName = newMenuItemValues.MealName;
                oldMenuItem.Description = newMenuItemValues.Description;
                oldMenuItem.Price = newMenuItemValues.Price;
                oldMenuItem.Ingredients = newMenuItemValues.Ingredients;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteExistingMenuItem(string menuItemToDelete)
        {
            MenuItem itemToDelete = GetMenuItemByName(menuItemToDelete);
            if (itemToDelete == null)
            {
                return false;
            }
            else
            {
                _menuItems.Remove(itemToDelete);
                return true;
            }
        }
    }
}
