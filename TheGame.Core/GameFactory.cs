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
            SetMainBoard(game, gameSettings.Curses, gameSettings.Characters);

            //put characters on first card

            return game;
        }

        private void SetMainBoard(Game game, List<GameOptions.AvailableCurses> curses, List<GameOptions.AvailableCharacters> characters)
        {
           var clueCards = game.SatchelAndNotebook.OfType<ClueCard>();
            var startingNumberAdventureCard = clueCards.Where(c=> curses.Contains(c.Curse) ).Min(c => c.StartingAdventureCard);
            game.MainBoard = new MainBoard(
                game.AdventureDeck.FirstOrDefault(c => c.Number == startingNumberAdventureCard && c.Color == Colors.Green), characters);
        }

        private void SetCharacterBoards(Game game, List<GameOptions.AvailableCharacters> characters)
        {
            foreach (var character in characters)
            {
                CharacterBoard board =
                    new CharacterBoard(game.CharacterCards.First(c => c.Character == character));

                game.CharacterBoards.Add(board);
            }
        }
        

        internal LoadedCardsResult LoadAllCards()
        {
            CardsFactory loader = new CardsFactory(cardsJsonFilepath);
            var jsonCards = loader.Start();
            var organizedCardBox = jsonCards.Map();
            return organizedCardBox;
        }

        private void SetupCardPilesForSelectedExtensions(Game game, LoadedCardsResult allLoadedCards, List<GameOptions.AvailableExtensions> gameExtensions, List<GameOptions.AvailableCharacters> characters, List<GameOptions.AvailableCurses> curses)
        {
            game.SatchelAndNotebook = allLoadedCards.SatchelAndNotebookCards.Select(c => new Card(c.Id, c.PictureFilepathBack, c.PictureFilepathFront, c.Origin)).Where(c => gameExtensions.Contains(c.Origin)).ToList();
            game.SatchelAndNotebook.AddRange(allLoadedCards.ClueCards.Where(c => curses.Contains(c.Curse)));

            game.DiscardPile = new PileOfCards<ActionCard>();//stays empty at the beginning of a game
            game.AdventureDeck.AddRange(allLoadedCards.AdventureCards.Where(c => gameExtensions.Contains(c.Origin)).ToList());
            game.ExplorationDeck.AddRange(allLoadedCards.ExplorationCards.Where(c => gameExtensions.Contains(c.Origin)).ToList());
            game.AdvancedSkillActionCards = allLoadedCards.AdvancedSkillActionCards.Where(c => gameExtensions.Contains(c.Origin)).ToList();

            game.ActionDeck = new PileOfCards<ActionCard>();
            game.ActionDeck.AddRange(allLoadedCards.SkillActionCards.Select(c => new ActionCard(c.Id, c.PictureFilepathBack, c.PictureFilepathFront, c.Origin)).Where(c => gameExtensions.Contains(c.Origin))); 
            game.ActionDeck.AddRange(allLoadedCards.CharacterSkillActionCards.Where(c => characters.Contains(c.Character)));
            game.ActionDeck.AddRange(allLoadedCards.ClueCursedActionCards.Where(c => curses.Contains(c.Curse)));
            game.ActionDeck.AddRange(allLoadedCards.CursedActionCards);

            game.CharacterCards = allLoadedCards.CharacterCards;
        }
    }
}