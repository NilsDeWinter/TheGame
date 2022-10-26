using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheGame.Core.Tests
{
    [TestClass]
    public class MainBoardTests
    {
        private MainBoard Board;

        [TestInitialize]
        public void Initialize()
        {
            Card card = new Card("0", "pathToPictureOfTheBack", "pathToPictureOfTheFront");
            Board = new MainBoard(card);
        }
        [TestMethod]
        public void When_OneCardIsAdded_Then_NumberOfCardsIsCorrect()
        {
            Card card = new Card("1", "", "");
            Board.AddCard(card, 0, 1);
            Assert.AreEqual(2, Board.listOfCards.Count);

            Card cardIdAlreadyOnBoard = new Card("1", "", "");
            try
            {
                Board.AddCard(card, 0, 2);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual($"The card is already on the board. Card: {cardIdAlreadyOnBoard}", e.Message);
                Assert.AreEqual(2, Board.listOfCards.Count); //no card added
            }

            Card cardOnOccupiedPosition = new Card("2", "", "");
            try
            {
                Board.AddCard(cardOnOccupiedPosition, 0, 0);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("The position is already occupied.", e.Message);
                Assert.AreEqual(2, Board.listOfCards.Count); //no card added
            }
        }
    }
}
