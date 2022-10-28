namespace TheGame.Core.Cards
{
    public class SaveCard : Card
    {
        public SaveCard(string id, string backPictureFilePath, string frontPictureFilePath, GameOptions.AvailableExtensions origin)
        : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
        }
    }
}