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

        public List<CharacterBoard> CharacterBoards { get; set; } = new List<CharacterBoard>();

        #region CardsPiles
        public List<Card> SatchelAndNotebook = new List<Card>(); 

        public PileOfCards<ActionCard> ActionDeck = new PileOfCards<ActionCard>();
        public PileOfCards<ActionCard> DiscardPile = new PileOfCards<ActionCard>();
        public List<AdventureCard> AdventureDeck = new List<AdventureCard>();
        public List<ExplorationCard> ExplorationDeck = new List<ExplorationCard>();

        public List<AdvancedSkillActionCard> AdvancedSkillActionCards = new List<AdvancedSkillActionCard>();
        public List<Card> BanishedCards = new List<Card>();
        public List<Card> PastCards = new List<Card>();

        public List<CharacterCard> CharacterCards { get; set; }
        #endregion

        
        public Game(GameSettings settings)
        {
            GameSettings = settings;
        }


    }
}
