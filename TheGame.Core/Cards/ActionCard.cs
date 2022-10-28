namespace TheGame.Core.Cards
{
    /// <summary>
    /// All types of ActionCards need to inherit from this class
    /// </summary>
    public class ActionCard : Card
    {
        public ActionCard(string id, string backPictureFilePath, string frontPictureFilePath, GameOptions.AvailableExtensions origin)
            : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
        }
    }
}