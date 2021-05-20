using _01_Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class CafeContentTests
    {
        private MenuItem _menuItems;
        private MenuRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _menuItems = new MenuItem(2, "Tenderloin", "this is pork", 11.00m, "bun, pork, mustard");
            _repo.AddItemToMenu(_menuItems);
        }

        [TestMethod]
        public void AddItemToMenu_ShouldReturnTrue()
        {
            MenuItem _items = new MenuItem(2, "This Little Piggy", "this is pork", 11.00m, "bun, pork, mustard");

            bool addMenuItem = _repo.AddItemToMenu(_menuItems);

            Assert.IsTrue(addMenuItem);
        }

        [TestMethod]
        public void UpdateExistingMenuItem_ShouldReturnNotEqual() 
        {
            MenuItem newMenuItem = new MenuItem(2, "This Little Piggy 2", "this is still pork", 12.50m, "bun, pork, lettuce, tomatoe, mustard, mayo");

            bool updateResult = _repo.UpdateMenuItem("This Little Piggy", newMenuItem);

            Assert.AreNotEqual(newMenuItem, updateResult);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            bool deleteResult = _repo.DeleteExistingMenuItem(_menuItems.MealName);

            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void GetMenuItems()
        {
            _repo.GetMenuItems();
        }
    }
}
