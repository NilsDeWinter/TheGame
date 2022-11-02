using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheGame.Core.Cards;

namespace TheGame.Core.Tests
{
    [TestClass]
    public class GameFactoryTests
    {
        private GameSettings _settings;
        private Game _game;

        [TestInitialize]
        public void Initialize()
        {
            List<GameOptions.AvailableCharacters> characters = new List<GameOptions.AvailableCharacters>
            {
                GameOptions.AvailableCharacters.FerdinandLachapelliere,
                GameOptions.AvailableCharacters.EliotPendleton
            };
            List<GameOptions.AvailableCurses> curses = new List<GameOptions.AvailableCurses>
            {
                GameOptions.AvailableCurses.TheVoraciousGoddess
            };
            List<GameOptions.AvailableExtensions> extensions = new List<GameOptions.AvailableExtensions>
            {
                GameOptions.AvailableExtensions.BaseBox
            };
            List<GameOptions.AvailableModes> modes = new List<GameOptions.AvailableModes>();

            _settings = new GameSettings("test", characters, curses, extensions, modes);
            GameFactory Factory = new GameFactory();
            _game = Factory.CreateGame(_settings);
        }

        [TestMethod]
        public void When_GameHasStarted_Then_CardPilesAreFilled()
        {
            Assert.IsTrue(_game.AdventureDeck.Count > 0);
            Assert.IsTrue(_game.SatchelAndNotebook.Count > 0);
            Assert.IsTrue(_game.ActionDeck.Count > 0);
            Assert.IsTrue(_game.AdvancedSkillActionCards.Count > 0);
            Assert.IsTrue(_game.BanishedCards.Count == 0);
            Assert.IsTrue(_game.DiscardPile.Count == 0);
            Assert.IsTrue(_game.ExplorationDeck.Count > 0);
            Assert.IsTrue(_game.PastCards.Count == 0);
        }

        [TestMethod]
        public void When_GameHasStarted_Then_MainBoardIsInitialized()
        {
            Assert.IsTrue(_game.MainBoard.listOfCards.Count > 0);
        }

        [TestMethod]
        public void When_GameHasStarted_Then_CharacterBoardsAreInitialized()
        {
            Assert.IsTrue(_game.CharacterBoards.Count > 0);

            for (int i = 0; i < _settings.Characters.Count; i++)
            {
                Assert.IsNotNull(_game.CharacterBoards[i].CharacterCard);
                Assert.IsTrue(_game.CharacterBoards[i].BonusCards.Count == 0);
                Assert.IsTrue(_game.CharacterBoards[i].Inventory.Count == 0);
                Assert.IsTrue(_game.CharacterBoards[i].SkillCards.Count == 0);
                Assert.IsTrue(_game.CharacterBoards[i].StateCards.Count == 0);
            }
        }


        [TestMethod]
        public void When_GameHasStarted_Then_CharactersAreOnFirstCard()
        {
            Assert.IsTrue(_game.MainBoard.listOfCharacters.Count == _settings.Characters.Count);
            for (int i = 0; i < _settings.Characters.Count; i++)
            {
                Assert.IsTrue(_game.MainBoard.listOfCharacters[i].PositionX == 0);
                Assert.IsTrue(_game.MainBoard.listOfCharacters[i].PositionY == 0);
            }
        }
    }
}
