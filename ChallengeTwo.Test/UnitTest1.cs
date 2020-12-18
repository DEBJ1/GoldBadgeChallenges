using ChallengeTwo.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeTwo.Test
{
    [TestClass]
    public class RepoTest
    {
        private ClaimContentRepo _claimRepo;
        private ClaimContent _claim;


        [TestIntialize]
        public void QueueTest()
        {
            _claimRepo = new ClaimContentRepo();
            _claim = new ClaimContent(1, ClaimType.Car, "Car accident on 464.", 400, new DateTime(2018 / 4 / 25), true);

            _claimRepo.AddClaimToQueue(_claim);
        }

        [TestMethod]
        public void AddClaimtoQueue_GetNull()
        {
            ClaimContent claim = new ClaimContent(1, ClaimType.Car, "Car accident on 464.", 400, new DateTime(2018 / 4 / 25), true);
            ClaimContentRepo repo = new ClaimContentRepo();


            repo.AddClaimToQueue(claim);
            ClaimContent claim1 = repo.GetClaimByID(1);

            Assert.IsNotNull(claim1);
        }

        [TestMethod]
        public void DeleteClaim_ShouldTrue()
        {
            ClaimContent claim1 = new ClaimContent(1, ClaimType.Car, "Car accident on 464.", 400, new DateTime(2018 / 4 / 25), true);
            bool delete = _claimRepo.RemoveClaim();

            Assert.IsTrue(delete);
        }
    }
}
