using System;
using System.Collections.Generic;
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
            List<GameOptions.AvailableCharacters> characters = new List<GameOptions.AvailableCharacters>
            {
                GameOptions.AvailableCharacters.FerdinandLachapelliere, GameOptions.AvailableCharacters.KeelanMcCluskey
            };
            _board = new MainBoard(card, characters);
        }

        [TestMethod]
        public void When_OneCardIsAdded_Then_NumberOfCardsIsCorrect()
        {
            var oldNbOfCards = _board.listOfCards.Count;

            Card card = new Card("1", "", "", GameOptions.AvailableExtensions.BaseBox);
            _board.LayCard(card, 0, 1);

            Assert.AreEqual(oldNbOfCards+1, _board.listOfCards.Count);

            Card cardIdAlreadyOnBoard = new Card("1", "", "", GameOptions.AvailableExtensions.BaseBox);
            try
            {
                _board.LayCard(card, 0, 2);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual($"The card is already on the board. Card: {cardIdAlreadyOnBoard}", e.Message);
                Assert.AreEqual(oldNbOfCards + 1, _board.listOfCards.Count); //no card added
            }

            Card cardOnOccupiedPosition = new Card("2", "", "", GameOptions.AvailableExtensions.BaseBox);
            try
            {
                _board.LayCard(cardOnOccupiedPosition, 0, 0);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("The position is already occupied.", e.Message);
                Assert.AreEqual(oldNbOfCards + 1, _board.listOfCards.Count); //no card added
            }
        }

        [TestMethod]
        public void When_CharacterIsPlacedOnExistingCard_Then_CharacterIsThere()
        {

            Card card = new Card("1", "", "", GameOptions.AvailableExtensions.BaseBox);
            _board.LayCard(card, 0, 1);


            _board.MoveCharacters(new List<GameOptions.AvailableCharacters>
            {
                GameOptions.AvailableCharacters.FerdinandLachapelliere
            }, 0, 1);

            var characterOnMainBoard = _board.listOfCharacters.First(c =>
                c.Character == GameOptions.AvailableCharacters.FerdinandLachapelliere);

            Assert.AreEqual((0, 1), (characterOnMainBoard.PositionX, characterOnMainBoard.PositionY));
        }
    }
}
