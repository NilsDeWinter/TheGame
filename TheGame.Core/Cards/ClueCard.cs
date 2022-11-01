using System;

namespace TheGame.Core.Cards
{
    public class ClueCard : Card
    {
        public GameOptions.AvailableCurses Curse { get; set; }

        public string StartingAdventureCard { get; set; }


        public ClueCard(string id, string backPictureFilePath, string frontPictureFilePath, GameOptions.AvailableCurses curse, string startingAdventureCard, GameOptions.AvailableExtensions origin)
            : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
            Curse = curse;
            StartingAdventureCard = startingAdventureCard;
        }
    }
}
