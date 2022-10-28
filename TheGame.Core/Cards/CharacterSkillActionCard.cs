namespace TheGame.Core.Cards
{
    public class CharacterSkillActionCard : ActionCard
    {
        public string CharacterName { get; set; }

        public CharacterSkillActionCard(string id, string backPictureFilePath, string frontPictureFilePath, string characterName, GameOptions.AvailableExtensions origin)
            : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
            CharacterName = characterName;
        }
    }
}
