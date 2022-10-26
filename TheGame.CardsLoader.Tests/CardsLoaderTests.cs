using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheGame.CardsLoader.Tests
{
    [TestClass]
    public class CardsLoaderTests
    {
        private OrganizedCardBox loadedCards;
        [TestInitialize]
        public void Initialize()
        {
            string jsonFilePath =
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty
                    , @"Resources\cards.json");
            CardsFactory factory = new CardsFactory(jsonFilePath);
            loadedCards = factory.Start();
        }
        [TestMethod]
        public void When_CardsAreLoaded_Then_BoxContainsCards()
        {
            Assert.IsTrue(loadedCards.ActionAdvancedSkillCards.Count > 0);
            Assert.IsTrue(loadedCards.ActionCharacterSkillCards.Count > 0);
            Assert.IsTrue(loadedCards.ActionCurseCards.Count > 0);
            Assert.IsTrue(loadedCards.ActionCurseClueCards.Count > 0);
            Assert.IsTrue(loadedCards.ActionSkillCards.Count > 0);
            Assert.IsTrue(loadedCards.AdventureCards.Count > 0);
            Assert.IsTrue(loadedCards.CharacterCards.Count > 0);
            Assert.IsTrue(loadedCards.ClueCards.Count > 0);
            Assert.IsTrue(loadedCards.ExplorationCards.Count > 0);
            Assert.IsTrue(loadedCards.SatchelAndJournalCards.Count > 0);
            Assert.IsTrue(loadedCards.SaveCards.Count > 0);
        }
    }
}
