using ChallengeOne.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeOne.Test
{
    [TestClass]
    public class MenuContentRepoTests
    {

        private MenuContentRepo _repo;
        private MenuContent _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuContentRepo();
            _content = new MenuContent(3, "Chickpea Salad", "Roasted chickpeas with suatued onion and peppers", "chickpeas,onion,pepper", 5);

            _repo.AddContentToList(_content);
        }

        //add function
        [TestMethod]

        public void AddtoList_ShouldGetNotNull()
        { //arrange- pulling everything out
            MenuContent content = new MenuContent();
            content.MealName = "Value Meal";
            MenuContentRepo Repository = new MenuContentRepo();
            //act
            Repository.AddContentToList(content);
            MenuContent contentFromDirectory = Repository.GetContentByName("Value Meal");
            //assert- verify expected outcome
            Assert.IsNotNull(contentFromDirectory);
        }

        //update
        [TestMethod]
        public void UpdateExistingContent()
        {
            //arrange
            //testinitialize
            MenuContent newContent = new MenuContent(3, "Chickpea Salad", "Roasted chickpeas with suatued onion and peppers", "chickpeas,onion,pepper", 5);

            //act 
            bool updateResult = _repo.UpdateExistingContent("3", newContent);

            //assert
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("3", true)]
        [DataRow("5", false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(string originalName, bool shouldUpdate)
        {
            //arrange
            //testinitialize
            MenuContent newContent = new MenuContent(3, "Chickpea Salad", "Roasted chickpeas with suatued onion and peppers", "chickpeas,onion,pepper", 5);

            //act 
            bool updateResult = _repo.UpdateExistingContent(originalName, newContent);

            //assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }


        [TestMethod]
        public void DeleteContent_Shouldreturntrue()
        {
            //arrange
            //act
            bool deleteResult =_repo.RemoveContentFromList(_content.MealName);

            Assert.IsTrue(deleteResult);
        }
    }
}
