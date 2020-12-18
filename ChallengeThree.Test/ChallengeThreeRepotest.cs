using ChallengeThree.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThree.Test
{
    [TestClass]
    public class ChallengeThreeRepotest
    {
        private BadgeRepo _badgeDict;
        private BadgeContent _badge;


        [TestMethod]
        public void Addtolist()
        {
            List<string> list = new List<string>();
            list.Add("D4");
            list.Add("D5");
            _badgeDict = new BadgeRepo();
            _badge = new BadgeContent(1, list);

            _badgeDict.AddBadgetoDict(_badge);
        }

        [TestMethod]
        public void AddtoDict_ShouldNotNull()
        {
            List<string> list = new List<string>();
            list.Add("D4");
            list.Add("D5");
            BadgeContent badge = new BadgeContent(1, list);
            BadgeRepo repo= new BadgeRepo();

            repo.AddBadgetoDict(badge);
            BadgeContent badge1 = repo.GetBadgeByKey(1);

            Assert.IsNotNull(badge1);
        }
    }
}
