using System;
using System.Collections.Generic;
using System.Text;
using TheGame.Core.Cards;

namespace TheGame.Core
{
    public class ContainerForAllLoadedCards
    {
        public List<CharacterCard> AllCharacterCards { get; set; } = new List<CharacterCard>();
        public List<ClueCard> AllClueCards { get; set; } = new List<ClueCard>();
        public List<ClueCurseActionCard> AllActionCurseClueCards { get; set; } = new List<ClueCurseActionCard>();
        public List<CurseActionCard> AllActionCurseCards { get; set; } = new List<CurseActionCard>();
        public List<SkillActionCard> AllActionSkillCards { get; set; } = new List<SkillActionCard>();
        public List<CharacterSkillActionCard> AllActionCharacterSkillCards { get; set; } = new List<CharacterSkillActionCard>();
        public List<AdvancedSkillActionCard> AllActionAdvancedSkillCards { get; set; } = new List<AdvancedSkillActionCard>();
        public List<ExplorationCard> AllExplorationCards { get; set; } = new List<ExplorationCard>();
        public List<AdventureCard> AllAdventureCards { get; set; } = new List<AdventureCard>();
        public List<SatchelAndNotebookCard> AllSatchelAndNotebookCards { get; set; } = new List<SatchelAndNotebookCard>();
        public List<SaveCard> AllSaveCards { get; set; } = new List<SaveCard>();
    }
}
