using ChallengeOne.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeOne.Test
{
    [TestClass]
    public class MenuContentTests
    {
        [TestMethod]
        public void SetName_ShouldSetCorrectString()
        {
            MenuContent content = new MenuContent();
            content.MealName = "Value Meal";

            string expected = "Value Meal";
            string actual = content.MealName;

            Assert.AreEqual(expected, actual);

        }
    }
}
