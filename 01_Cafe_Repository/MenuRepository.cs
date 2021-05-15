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
        //public MenuItem GetMenuItemByDescription(string description)
        //{

        //}
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
        public bool UpdateExistingMenuItem(string originalMenuItem, MenuItem newMenuItemValues)
        {
            MenuItem oldMenuItem = GetMenuItemByName(originalMenuItem);
            if (oldMenuItem != null)
            {
                oldMenuItem.MealNumber = newMenuItemValues.MealNumber;
                oldMenuItem.MealName = newMenuItemValues.MealName;
                oldMenuItem.Description = newMenuItemValues.Description;
                oldMenuItem.Price = newMenuItemValues.Price;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteExistingMenuItem(string v)
        {
            throw new NotImplementedException();
        }
    }
}
