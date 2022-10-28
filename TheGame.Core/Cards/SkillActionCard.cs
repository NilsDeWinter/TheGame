namespace TheGame.Core.Cards
{
    public class SkillActionCard : ActionCard
    {
        public SkillActionCard(string id, string backPictureFilePath, string frontPictureFilePath, GameOptions.AvailableExtensions origin)
        :base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
        }
    }
}