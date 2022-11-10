namespace TheGame.Core.Cards
{
    public class ClueCursedActionCard : ActionCard
    {
        public GameOptions.AvailableCurses Curse { get; set; }

        public ClueCursedActionCard(string id, string backPictureFilePath, string frontPictureFilePath, GameOptions.AvailableExtensions origin, GameOptions.AvailableCurses curse) 
            : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
            Curse = curse;
        }
    }
}
