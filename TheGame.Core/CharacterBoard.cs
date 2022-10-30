using System;
using System.Collections.Generic;
using TheGame.Core.Cards;

namespace TheGame.Core
{
    public class CharacterBoard
    {
        public CharacterCard CharacterCard { get; set; }
        public List<InventoryItem> Inventory { get; set; } = new List<InventoryItem>(); //items/objects in game (blue hands cards that have been built or found objects in exploration cards or adventure cards)
        public List<AdventureCard> StateCards { get; set; } = new List<AdventureCard>(); //red hand cards
        public List<Card> BonusCards { get; set; } = new List<Card>(); //green hand cards
        public List<ActionCard> SkillCards { get; set; } = new List<ActionCard>(); //blue hand cards which are skills (not yet turned into items/objects)

        public CharacterBoard(CharacterCard characterCard)
        {
            CharacterCard = characterCard;
        }

        public class InventoryItem
        {
            private int _durability;

            public int Durability
            {
                get => _durability;
                set => _durability = value < 0 ? 0 : (value > 6 ? 6 : value);
            }

            public List<Card> Cards { get; set; } //can be exploration cards, adventure cards, blue hand cards turned into items/objects

            public InventoryItem(List<Card> cards, int durability)
            {
                Cards = cards;
                Durability = durability;
                //Uuid = Guid.NewGuid();
            }
        }
    }
    
}
