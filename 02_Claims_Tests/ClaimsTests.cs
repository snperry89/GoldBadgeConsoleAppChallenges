using _02_Claims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_Claims_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        //[TestInitialize]      //how to do this???
        //public void Arrange()
        //{
        //    Claims claim = new Claims();
        //    ClaimsRepo2 repo = new ClaimsRepo2();
        //}

        [TestMethod]
        public void SetClaimsID_ShouldSetCorrectInt()
        {
            Claims claim = new Claims();
            claim.ClaimID = 12;

            int expected = 12;
            int actual = claim.ClaimID;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddNewClaim_ShouldGetCorrectBoolean()
        {
            Claims claim = new Claims();
            ClaimsRepo2 repo = new ClaimsRepo2();

            bool addClaim = repo.CreateNewClaim(claim);

            Assert.IsTrue(addClaim);
        }

        [TestMethod]
        public void GetClaims_ShouldReturnClaims()
        {
            Claims claim = new Claims();
            ClaimsRepo2 repo = new ClaimsRepo2();
            repo.CreateNewClaim(claim);

            Queue<Claims> directory = repo.GetClaims();

            bool directoryHasClaim = directory.Contains(claim);
            Assert.IsTrue(directoryHasClaim);

        }
    }
}
