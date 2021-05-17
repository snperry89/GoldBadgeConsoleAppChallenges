using _02_Claims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_Claims_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void SetClaimsID_ShouldSetCorrectInt()
        {
            Claims claim = new Claims();

            claim.ClaimID = 12;

            int expected = 12;
            int actual = claim.ClaimID;

            Assert.AreEqual(expected, actual);      
        }
    }
}
