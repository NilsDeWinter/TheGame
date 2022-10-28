using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheGame.CardsLoader.Tests
{
    [TestClass]
    public class CardsLoaderTests
    {
        private OrganizedJsonCardsContainer _loadedJsonCards;
        [TestInitialize]
        public void Initialize()
        {
            string jsonFilePath =
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty
                    , @"Resources\cards.json");
            CardsFactory factory = new CardsFactory(jsonFilePath);
            _loadedJsonCards = factory.Start();
        }
        [TestMethod]
        public void When_CardsAreLoaded_Then_BoxContainsCards()
        {
            Assert.IsTrue(_loadedJsonCards.ActionAdvancedSkillCards.Count > 0);
            Assert.IsTrue(_loadedJsonCards.ActionCharacterSkillCards.Count > 0);
            Assert.IsTrue(_loadedJsonCards.ActionCurseCards.Count > 0);
            Assert.IsTrue(_loadedJsonCards.ActionCurseClueCards.Count > 0);
            Assert.IsTrue(_loadedJsonCards.ActionSkillCards.Count > 0);
            Assert.IsTrue(_loadedJsonCards.AdventureCards.Count > 0);
            Assert.IsTrue(_loadedJsonCards.CharacterCards.Count > 0);
            Assert.IsTrue(_loadedJsonCards.ClueCards.Count > 0);
            Assert.IsTrue(_loadedJsonCards.ExplorationCards.Count > 0);
            Assert.IsTrue(_loadedJsonCards.SatchelAndJournalCards.Count > 0);
            Assert.IsTrue(_loadedJsonCards.SaveCards.Count > 0);
        }
    }
}
