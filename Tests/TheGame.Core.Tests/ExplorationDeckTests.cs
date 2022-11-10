using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheGame.Core.Cards;

namespace TheGame.Core.Tests
{
    [TestClass]
    public class ExplorationDeckTests
    {
        private ExplorationDeck _explorationDeck;
        private readonly int _numberOfCardsInDeck = 100;
        private readonly int _numberOfAreasInDeck = 10;

        [TestInitialize]
        public void Initialize()
        {
            _explorationDeck =  new ExplorationDeck();
            for (int cardId = 0; cardId < _numberOfCardsInDeck; cardId++)
            {

                var area = (cardId / _numberOfAreasInDeck + 1).ToString();
                _explorationDeck.Add(new ExplorationCard(cardId.ToString(), $"back_{cardId}", $"front_{cardId}", GameOptions.AvailableExtensions.BaseBox, area));
            }
        }

        [TestMethod]
        public void When_PickCardFromArea_Then_CardIsNoMoreInDeck()
        {
            ExplorationCard pickedCard = _explorationDeck.PickCardFromArea("1");

            Assert.IsNotNull(pickedCard);
            Assert.IsFalse(_explorationDeck.Contains(pickedCard));
            Assert.IsTrue(_explorationDeck.Contains(_explorationDeck[0]));
        }

        [TestMethod]
        public void When_PickCardFromEmptyArea_Then_NoCardReturned()
        {
            ExplorationCard pickedCard = _explorationDeck.PickCardFromArea("EmptyAreaWithNoCards");

            Assert.IsNull(pickedCard);
        }
    }
}
