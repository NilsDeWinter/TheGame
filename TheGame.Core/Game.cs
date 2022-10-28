using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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

        #region CardsPiles
        public List<Card> SatchelAndNotebook = new List<Card>(); 

        public List<ActionCard> ActionDeck = new List<ActionCard>();
        public List<ActionCard> DiscardPile = new List<ActionCard>();
        public List<AdventureCard> AdventureDeck = new List<AdventureCard>();
        public List<ExplorationCard> ExplorationDeck = new List<ExplorationCard>();

        public List<AdvancedSkillActionCard> AdvancedSkillActionCards = new List<AdvancedSkillActionCard>();
        public List<Card> BanishedCards = new List<Card>();
        public List<Card> PastCards = new List<Card>();
        #endregion

        private static readonly string cardsJsonFilepath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, @"Resources\cards.json");

        public Game(GameSettings settings)
        {
            GameSettings = settings;
        }

        private void Initialize()
        {
            //load cards and put them in the right piles
            LoadCardsForSelectedGameExtensionsAndPutThemInPlace();


            //initialize characters boards
            //put first card on board (ie initialize mainboard)
            //put characters on first card
            //put curses clue cards in satchel
        }

        private void LoadCardsForSelectedGameExtensionsAndPutThemInPlace()
        {
            var allCards = LoadAllCards();
            KeepCardsForSelectedGameExtensions(allCards, GameSettings.GameExtensions);
        }

        internal ContainerForAllLoadedCards LoadAllCards()
        {
            CardsFactory loader = new CardsFactory(cardsJsonFilepath);
            var jsonCards = loader.Start();
            var organizedCardBox = jsonCards.Map();
            return organizedCardBox;
        }

        private void KeepCardsForSelectedGameExtensions(ContainerForAllLoadedCards allCards, List<GameOptions.AvailableExtensions> selectedGameExtensions)
        {
            SatchelAndNotebook = allCards.AllSatchelAndNotebookCards.Select(c=> new Card(c.Id, c.PictureFilepathBack, c.PictureFilepathFront, c.Origin)).Where(c => selectedGameExtensions.Contains(c.Origin)).ToList();
            DiscardPile = new List<ActionCard>();//stays empty at the beginning of a game
            AdventureDeck = allCards.AllAdventureCards.Where(c => selectedGameExtensions.Contains(c.Origin)).ToList();
            ExplorationDeck = allCards.AllExplorationCards.Where(c => selectedGameExtensions.Contains(c.Origin)).ToList();
            AdvancedSkillActionCards = allCards.AllActionAdvancedSkillCards.Where(c=> selectedGameExtensions.Contains(c.Origin)).ToList();

            ActionDeck = new List<ActionCard>(); //TODO:fill correctly 

            throw new NotImplementedException(); //TODO implement


        }
    }
}
