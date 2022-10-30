using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using TheGame.CardsLoader;
using TheGame.Core.Cards;

namespace TheGame.Core
{
    /// <summary>
    /// For each new game you want to start, call the constructor with GameSettings and then call Initialize()
    /// </summary>
    public class Game
    {
        public GameSettings GameSettings { get; set; }
        public MainBoard MainBoard { get; set; }

        public List<CharacterBoard> CharacterBoards { get; set; }

        #region CardsPiles
        public List<Card> SatchelAndNotebook = new List<Card>(); 

        public List<ActionCard> ActionDeck = new List<ActionCard>();
        public List<ActionCard> DiscardPile = new List<ActionCard>();
        public List<AdventureCard> AdventureDeck = new List<AdventureCard>();
        public List<ExplorationCard> ExplorationDeck = new List<ExplorationCard>();

        public List<AdvancedSkillActionCard> AdvancedSkillActionCards = new List<AdvancedSkillActionCard>();
        public List<Card> BanishedCards = new List<Card>();
        public List<Card> PastCards = new List<Card>();

        public List<CharacterCard> CharacterCards { get; set; }
        #endregion

        private static readonly string cardsJsonFilepath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, @"Resources\cards.json");

        public Game(GameSettings settings)
        {
            GameSettings = settings;
        }

        #region Initializing game

        
        private void Initialize()
        {
            //load cards and put them in the right piles
            LoadCardsForSelectedGameExtensionsAndPutThemInPlace();

            //initialize characters boards
            SetCharacterBoards();

            //put first card on board (ie initialize mainboard)
            //put curses clue cards in satchel
            //put characters on first card
        }

        private void SetCharacterBoards()
        {
            foreach (var character in GameSettings.Characters)
            {
                CharacterBoard board =
                    new CharacterBoard(CharacterCards.First(c => c.Character == character));
            }
        }

        private void LoadCardsForSelectedGameExtensionsAndPutThemInPlace()
        {
            var allCards = LoadAllCards();
            KeepCardsForSelectedGameExtensions(allCards);
        }

        internal ContainerForAllLoadedCards LoadAllCards()
        {
            CardsFactory loader = new CardsFactory(cardsJsonFilepath);
            var jsonCards = loader.Start();
            var organizedCardBox = jsonCards.Map();
            return organizedCardBox;
        }

        private void KeepCardsForSelectedGameExtensions(ContainerForAllLoadedCards allCards)
        {
            SatchelAndNotebook = allCards.AllSatchelAndNotebookCards.Select(c=> new Card(c.Id, c.PictureFilepathBack, c.PictureFilepathFront, c.Origin)).Where(c => GameSettings.GameExtensions.Contains(c.Origin)).ToList();
            DiscardPile = new List<ActionCard>();//stays empty at the beginning of a game
            AdventureDeck = allCards.AllAdventureCards.Where(c => GameSettings.GameExtensions.Contains(c.Origin)).ToList();
            ExplorationDeck = allCards.AllExplorationCards.Where(c => GameSettings.GameExtensions.Contains(c.Origin)).ToList();
            AdvancedSkillActionCards = allCards.AllAdvancedSkillActionCards.Where(c=> GameSettings.GameExtensions.Contains(c.Origin)).ToList();

            ActionDeck = allCards.AllSkillActionCards.Select(c=> new ActionCard(c.Id, c.PictureFilepathBack, c.PictureFilepathFront, c.Origin)).Where(c => GameSettings.GameExtensions.Contains(c.Origin)).ToList();
            ActionDeck.AddRange(allCards.AllCharacterSkillActionCards.Where(c => GameSettings.Characters.Contains(c.Character)));
            ActionDeck.AddRange(allCards.AllClueCursedActionCards.Where(c => GameSettings.Curses.Contains(c.Curse)));
            ActionDeck.AddRange(allCards.AllCursedActionCards);

            CharacterCards = allCards.AllCharacterCards;
        }

        #endregion
    }
}
