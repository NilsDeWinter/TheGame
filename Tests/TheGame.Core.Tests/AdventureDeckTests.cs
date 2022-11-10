using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheGame.Core.Cards;
using TheGame.Core.Decks;

namespace TheGame.Core.Tests
{
    [TestClass]
    public class AdventureDeckTests
    {
        private AdventureDeck _adventureDeck;
        private readonly int _numberOfSingleGreenCardsInDeck = 5;
        private readonly int _numberOfDoubledGreenCardsInDeck = 2;

        [TestInitialize]
        public void Initialize()
        {
            _adventureDeck =  new AdventureDeck();

            for (int number = 1; number < _numberOfSingleGreenCardsInDeck; number++)
            {
                int cardId = number;
                _adventureDeck.Add(new AdventureCard(cardId.ToString(), $"back_{cardId}", $"front_{cardId}", GameOptions.AvailableExtensions.BaseBox, number.ToString(), Colors.Green));
            }

            int lastSingleGreenCardId = _adventureDeck.Count;
            for (int number = 1; number < _numberOfDoubledGreenCardsInDeck;number++)
            {
                int cardId = lastSingleGreenCardId+number;
                _adventureDeck.Add(new AdventureCard(cardId.ToString(), $"back_{cardId}", $"front_{cardId}", GameOptions.AvailableExtensions.BaseBox, number.ToString(), Colors.Green));
            }

            string yellowCardId = "yellow1";
            string yellowCardNumber = "1";
            _adventureDeck.Add(new AdventureCard(yellowCardId, $"back_{yellowCardId}", $"front_{yellowCardId}", GameOptions.AvailableExtensions.BaseBox, yellowCardNumber, Colors.Yellow));

            yellowCardId = "yellow2";
            yellowCardNumber = "6";
            _adventureDeck.Add(new AdventureCard(yellowCardId, $"back_{yellowCardId}", $"front_{yellowCardId}", GameOptions.AvailableExtensions.BaseBox, yellowCardNumber, Colors.Yellow));
        }

        [TestMethod]
        public void When_PickCardAndThereIsGreenAndYellow_Then_CardIsGreenAndNoMoreInDeck()
        {
            var number = "1";
            AdventureCard pickedCard = _adventureDeck.PickCard(number);

            Assert.IsNotNull(pickedCard);
            Assert.AreEqual(number, pickedCard.Number);

            Assert.AreEqual(Colors.Green, pickedCard.Color);

            Assert.IsFalse(_adventureDeck.Contains(pickedCard));
        }


        [TestMethod]
        public void When_PickCardAndThereIsOnlyYellow_Then_CardIsYellowAndNoMoreInDeck()
        {
            var number = "6";
            AdventureCard pickedCard = _adventureDeck.PickCard(number);

            Assert.IsNotNull(pickedCard);
            Assert.AreEqual(number, pickedCard.Number);

            Assert.AreEqual(Colors.Yellow, pickedCard.Color);

            Assert.IsFalse(_adventureDeck.Contains(pickedCard));
        }

        [TestMethod]
        public void When_PickCardFromEmptyArea_Then_NoCardReturned()
        {
            AdventureCard pickedCard = _adventureDeck.PickCard("NumberWithNoCards");

            Assert.IsNull(pickedCard);
        }
    }
}
