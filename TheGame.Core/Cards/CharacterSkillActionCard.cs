namespace TheGame.Core.Cards
{
    public class CharacterSkillActionCard : ActionCard
    {
        public GameOptions.AvailableCharacters Character { get; set; }

        public CharacterSkillActionCard(string id, string backPictureFilePath, string frontPictureFilePath, GameOptions.AvailableCharacters character, GameOptions.AvailableExtensions origin)
            : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
            Character = character;
        }
    }
}
