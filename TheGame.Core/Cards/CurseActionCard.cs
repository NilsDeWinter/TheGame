namespace TheGame.Core.Cards
{
    public class CurseActionCard : ActionCard
    {
        public CurseActionCard(string id, string backPictureFilePath, string frontPictureFilePath, GameOptions.AvailableExtensions origin)
        :base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
        }
    }
}