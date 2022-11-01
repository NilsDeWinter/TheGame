using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheGame.CardsLoader.Tests
{
    [TestClass]
    public class CardsLoaderTests
    {
        private List<JsonCard> _loadedJsonCards;
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
            Assert.IsTrue(_loadedJsonCards.Count > 0);
        }
    }
}
