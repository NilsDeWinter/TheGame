using System;
using System.Collections.Generic;
using System.Text;
using TheGame.Core.Cards;

namespace TheGame.Core
{
    public class LoadedCardsResult
    {
        public List<CharacterCard> CharacterCards { get; set; } = new List<CharacterCard>();
        public List<ClueCard> ClueCards { get; set; } = new List<ClueCard>();
        public List<ClueCursedActionCard> ClueCursedActionCards { get; set; } = new List<ClueCursedActionCard>();
        public List<CursedActionCard> CursedActionCards { get; set; } = new List<CursedActionCard>();
        public List<SkillActionCard> SkillActionCards { get; set; } = new List<SkillActionCard>();
        public List<CharacterSkillActionCard> CharacterSkillActionCards { get; set; } = new List<CharacterSkillActionCard>();
        public List<AdvancedSkillActionCard> AdvancedSkillActionCards { get; set; } = new List<AdvancedSkillActionCard>();
        public List<ExplorationCard> ExplorationCards { get; set; } = new List<ExplorationCard>();
        public List<AdventureCard> AdventureCards { get; set; } = new List<AdventureCard>();
        public List<SatchelAndNotebookCard> SatchelAndNotebookCards { get; set; } = new List<SatchelAndNotebookCard>();
        public List<SaveCard> SaveCards { get; set; } = new List<SaveCard>();
    }
}
