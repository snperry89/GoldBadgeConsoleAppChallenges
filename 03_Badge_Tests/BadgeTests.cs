using _03_Badge_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_Badge_Tests
{
    [TestClass]
    public class BadgeTests
    {
        [TestMethod]
        public void AddNewBadge_ShouldReturnCorrectBoolean()
        {
            bool wasAdded;
            Badge badge = new Badge();
            BadgeRepo badgeRepo = new BadgeRepo();

            wasAdded = badgeRepo.CreateNewBadge(badge);
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void GetBadges_ShouldReturnDictionary()
        {
            Badge badge = new Badge();
            BadgeRepo badgeRepo = new BadgeRepo();
            badgeRepo.CreateNewBadge(badge);

            Dictionary<int, List<string>> badgeRepoTwo = badgeRepo.GetBadges();
            Assert.IsTrue(badgeRepoTwo.ContainsKey(badge.BadgeID));
        }

        ///????
        [TestMethod]
        public void UpdateDoors_ShouldReturnCorrectBoolean()
        {
            Badge badge = new Badge(1, new List<string> { "A1", "B2" });
            BadgeRepo badgeRepo = new BadgeRepo();
            badgeRepo.CreateNewBadge(badge);
            bool wasUpdated;
            wasUpdated = badgeRepo.UpdateDoors(1, badge);

            Assert.IsTrue(wasUpdated);
        }
    }
}
