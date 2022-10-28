namespace TheGame.Core.Cards
{
    public class ExplorationCard : Card
    {
        public string Area { get; set; }

        public ExplorationCard(string id, string backPictureFilePath, string frontPictureFilePath, string area, GameOptions.AvailableExtensions origin)
            : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
            Area = area;
        }
    }
}
