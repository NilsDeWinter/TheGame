using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheGame.Core.Cards;

namespace TheGame.Core.Tests
{
    [TestClass]
    public class PileOfCardsTests
    {
        private PileOfCards<Card> _deckOfCards;
        private readonly int _numberOfCardsInDeck = 50;
        /// <summary>
        /// Must be less than _numberOfCardsInDeck
        /// </summary>
        private readonly int _smallAmountOfCardsToPick = 2;

        /// <summary>
        /// Must be more than _numberOfCardsInDeck
        /// </summary>
        private readonly int _bigAmountOfCardsToPick = 100;

        [TestInitialize]
        public void Initialize()
        {
            _deckOfCards = new PileOfCards<Card>();
            for (int i = 0; i < _numberOfCardsInDeck; i++)
            {
                _deckOfCards.Add(new Card(i.ToString(), $"back_{i}", $"front_{i}", GameOptions.AvailableExtensions.BaseBox));
            }
        }

        [TestMethod]
        public void When_CardsAreShuffled_Then_CardsAreInDifferentOrder()
        {
            var cardIdsBeforeShuffling = _deckOfCards.Select(c => c.Id).ToList();

            _deckOfCards.Shuffle();

            var cardIdsAfterShuffling = _deckOfCards.Select(c => c.Id).ToList();

            CollectionAssert.AreNotEqual(cardIdsBeforeShuffling, cardIdsAfterShuffling);
        }

        [TestMethod]
        public void When_SmallAmountOfCardsArePickedOnTop_Then_PileOfCardIsSmallerAndLacksTheseCards()
        {
            var cardIdsBeforeShuffling = _deckOfCards.Select(c => c.Id).ToList();

            var pickedCards = _deckOfCards.PickCardsOnTop(_smallAmountOfCardsToPick);
            foreach (var pickedCard in pickedCards.pickedCards)
            {
                CollectionAssert.DoesNotContain(_deckOfCards, pickedCard);
            }
            Assert.IsTrue(pickedCards.hadEnoughCards);
            Assert.AreNotEqual(cardIdsBeforeShuffling.Count, _deckOfCards.Count);
            Assert.IsFalse(cardIdsBeforeShuffling[0] == _deckOfCards[0].Id);
            Assert.IsTrue(cardIdsBeforeShuffling[^1] == _deckOfCards[^1].Id);
        }


        [TestMethod]
        public void When_TooManyCardsArePickedOnTop_Then_PileOfCardIsEmpty()
        {
            var pickedCards = _deckOfCards.PickCardsOnTop(_bigAmountOfCardsToPick);

            Assert.AreEqual(0, _deckOfCards.Count);
            Assert.IsFalse(pickedCards.hadEnoughCards);
        }


    }
}
