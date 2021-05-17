﻿using _01_Cafe_Repository;
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
            _menuItems = new MenuItem(2, "Tenderloin", "this is pork", 11, "bun, pork, mustard");
            _repo.AddItemToMenu(_menuItems);
        }

        [TestMethod]
        public void AddItemToMenu_ShouldReturnTrue()
        {
            MenuItem _items = new MenuItem(2, "This Little Piggy", "this is pork", 11, "bun, pork, mustard");

            bool addMenuItem = _repo.AddItemToMenu(_menuItems);

            Assert.IsTrue(addMenuItem);
        }

        [TestMethod]
        public void UpdateExistingMenuItem()
        {
            _repo.UpdateExistingMenuItem("This Little Piggy", new MenuItem(2, "This Little Piggy 2", "this is still pork", 12.50, "bun, pork, lettuce, tomatoe, mustard, mayo"));
        }

        [TestMethod]
        public void DeleteExistingMenuItem()
        {
            bool wasDeleted = _repo.DeleteExistingMenuItem("This Little Piggy");

            Assert.IsTrue(wasDeleted); ///works if isFalse, but shouldnt it be IsTrue
        }

        [TestMethod]
        public void GetMenuItems()
        {
            _repo.GetMenuItems();
        }
    }
}
