using System;

namespace TheGame.Core.Cards
{
    public class ClueCard : Card
    {
        public GameOptions.AvailableCurses Curse { get; set; }

        public string StartingAdventureCard { get; set; }


        public ClueCard(string id, string pictureFilepathBack, string pictureFilepathFront, GameOptions.AvailableExtensions origin, GameOptions.AvailableCurses curse, string startingAdventureCard) 
            : base(id, pictureFilepathBack, pictureFilepathFront, origin)
        {
            Curse = curse;
            StartingAdventureCard = startingAdventureCard;
        }
    }
}
