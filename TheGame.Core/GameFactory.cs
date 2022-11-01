using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using TheGame.CardsLoader;
using TheGame.Core.Cards;

namespace TheGame.Core
{
    public class GameFactory
    {
        private static readonly string cardsJsonFilepath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, @"Resources\cards.json");
        


        public Game CreateGame(GameSettings gameSettings)
        {
            Game game = new Game(gameSettings);

            //load cards and put them in the right piles
            var allCards = LoadAllCards();
            SetupCardPilesForSelectedExtensions(game, allCards, gameSettings.GameExtensions, gameSettings.Characters, gameSettings.Curses);

            //initialize characters boards
            SetCharacterBoards(game, gameSettings.Characters);


            //put first card on board (ie initialize mainboard)
            SetMainBoard(game, allCards, gameSettings.Curses);

            //put characters on first card

            return game;
        }

        private void SetMainBoard(Game game, ContainerForCards allCards, List<GameOptions.AvailableCurses> curses)
        {
            var startingNumberAdventureCard = allCards.ClueCards.Where(c=> curses.Contains(c.Curse) ).Min(c => c.StartingAdventureCard);
            game.MainBoard = new MainBoard(
                allCards.AdventureCards.FirstOrDefault(c => c.Number == startingNumberAdventureCard && c.Color == Colors.Green));
        }

        private void SetCharacterBoards(Game game, List<GameOptions.AvailableCharacters> characters)
        {
            foreach (var character in characters)
            {
                CharacterBoard board =
                    new CharacterBoard(game.CharacterCards.First(c => c.Character == character));
            }
        }
        

        internal ContainerForCards LoadAllCards()
        {
            CardsFactory loader = new CardsFactory(cardsJsonFilepath);
            var jsonCards = loader.Start();
            var organizedCardBox = jsonCards.Map();
            return organizedCardBox;
        }

        private void SetupCardPilesForSelectedExtensions(Game game, ContainerForCards allCards, List<GameOptions.AvailableExtensions> gameExtensions, List<GameOptions.AvailableCharacters> characters, List<GameOptions.AvailableCurses> curses)
        {
            game.SatchelAndNotebook = allCards.SatchelAndNotebookCards.Select(c => new Card(c.Id, c.PictureFilepathBack, c.PictureFilepathFront, c.Origin)).Where(c => gameExtensions.Contains(c.Origin)).ToList();
            game.SatchelAndNotebook.AddRange(allCards.ClueCards.Where(c => curses.Contains(c.Curse)));

            game.DiscardPile = new List<ActionCard>();//stays empty at the beginning of a game
            game.AdventureDeck = allCards.AdventureCards.Where(c => gameExtensions.Contains(c.Origin)).ToList();
            game.ExplorationDeck = allCards.ExplorationCards.Where(c => gameExtensions.Contains(c.Origin)).ToList();
            game.AdvancedSkillActionCards = allCards.AdvancedSkillActionCards.Where(c => gameExtensions.Contains(c.Origin)).ToList();

            game.ActionDeck = allCards.SkillActionCards.Select(c => new ActionCard(c.Id, c.PictureFilepathBack, c.PictureFilepathFront, c.Origin)).Where(c => gameExtensions.Contains(c.Origin)).ToList();
            game.ActionDeck.AddRange(allCards.CharacterSkillActionCards.Where(c => characters.Contains(c.Character)));
            game.ActionDeck.AddRange(allCards.ClueCursedActionCards.Where(c => curses.Contains(c.Curse)));
            game.ActionDeck.AddRange(allCards.CursedActionCards);

            game.CharacterCards = allCards.CharacterCards;
        }
    }
}