using _02_Claims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_Claims_Tests
{
    [TestClass]
    public class ClaimsRepoTests
    {
        private ClaimsRepo _repo;
        private Claims _claims;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _claims = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);

            _repo.AddClaim(_claims);
        }
        // Add method
        [TestMethod]
        public void AddClaimToList_ShouldGetNotNull()
        {
            // Arrange -- set up playing field
            Claims claim = new Claims();
            claim.ClaimID = 2;
            ClaimsRepo repo = new ClaimsRepo();
            // Act -- get/run the code we want to test
            repo.AddClaim(claim);
            Claims claimFromList = repo.ViewClaimByClaimID(2);
            // Assert -- use assert class to verify the expected outcome
            Assert.IsNotNull(claimFromList);
        }

        // update method
        [TestMethod]
        public void UpdateClaim_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialize
            Claims newClaim = new Claims(1, ClaimType.Home, "Car accident on 469", 600.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            //Act
            bool updateResult = _repo.UpdateClaim(1, newClaim);

            //Assert
            Assert.IsTrue(updateResult);
        }
        //dont fully understand below---minute 22 Repo Testing Video
        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]
        public void UpdateClaim_ShouldMatchGivenBool(int originalClaimID, bool shouldUpdate)
        {
            //Arrange
            //TestInitialize
            Claims newClaim = new Claims(1, ClaimType.Car, "Car accident on 469", 600.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            //Act
            bool updatedClaim = _repo.UpdateClaim(originalClaimID, newClaim);

            //Assert
            Assert.AreEqual(shouldUpdate, updatedClaim);
        }
    }
}
