namespace TheGame.Core.Cards
{
    public class ClueCurseActionCard : ActionCard
    {
        public string CurseName { get; set; }

        public ClueCurseActionCard(string id, string backPictureFilePath, string frontPictureFilePath, string curseName, GameOptions.AvailableExtensions origin)
            : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
            CurseName = curseName;
        }
    }
}
