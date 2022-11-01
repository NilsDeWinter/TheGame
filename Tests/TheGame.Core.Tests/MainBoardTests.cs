using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheGame.Core.Cards;

namespace TheGame.Core.Tests
{
    [TestClass]
    public class MainBoardTests
    {
        private MainBoard _board;

        [TestInitialize]
        public void Initialize()
        {
            Card card = new Card("0", "pathToPictureOfTheBack", "pathToPictureOfTheFront", GameOptions.AvailableExtensions.BaseBox);
            _board = new MainBoard(card);
        }

        [TestMethod]
        public void When_OneCardIsAdded_Then_NumberOfCardsIsCorrect()
        {
            Card card = new Card("1", "", "", GameOptions.AvailableExtensions.BaseBox);
            _board.AddCard(card, 0, 1);
            Assert.AreEqual(2, _board.listOfCards.Count);

            Card cardIdAlreadyOnBoard = new Card("1", "", "", GameOptions.AvailableExtensions.BaseBox);
            try
            {
                _board.AddCard(card, 0, 2);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual($"The card is already on the board. Card: {cardIdAlreadyOnBoard}", e.Message);
                Assert.AreEqual(2, _board.listOfCards.Count); //no card added
            }

            Card cardOnOccupiedPosition = new Card("2", "", "", GameOptions.AvailableExtensions.BaseBox);
            try
            {
                _board.AddCard(cardOnOccupiedPosition, 0, 0);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("The position is already occupied.", e.Message);
                Assert.AreEqual(2, _board.listOfCards.Count); //no card added
            }
        }
    }
}
