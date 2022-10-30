namespace TheGame.Core.Cards
{
    public class CursedActionCard : ActionCard
    {
        public CursedActionCard(string id, string backPictureFilePath, string frontPictureFilePath, GameOptions.AvailableExtensions origin)
        :base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
        }
    }
}