namespace TheGame.Core.Cards
{
    public class ClueCursedActionCard : ActionCard
    {
        public GameOptions.AvailableCurses Curse { get; set; }

        public ClueCursedActionCard(string id, string backPictureFilePath, string frontPictureFilePath, GameOptions.AvailableCurses curse, GameOptions.AvailableExtensions origin)
            : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
            Curse = curse;
        }
    }
}
