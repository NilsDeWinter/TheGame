namespace TheGame.Core.Cards
{
    public class AdvancedSkillActionCard : ActionCard
    {
        public AdvancedSkillActionCard(string id, string backPictureFilePath, string frontPictureFilePath, GameOptions.AvailableExtensions origin)
        :base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
        }
    }
}