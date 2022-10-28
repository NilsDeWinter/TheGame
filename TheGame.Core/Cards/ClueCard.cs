namespace TheGame.Core.Cards
{
    public class ClueCard : Card
    {
        public string CurseName { get; set; }

        public string StartingAdventureCard { get; set; }


        public ClueCard(string id, string backPictureFilePath, string frontPictureFilePath, string curseName, string startingAdventureCard, GameOptions.AvailableExtensions origin)
            : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
            CurseName = curseName;
            StartingAdventureCard = startingAdventureCard;
        }
    }
}
