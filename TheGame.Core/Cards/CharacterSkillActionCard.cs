namespace TheGame.Core.Cards
{
    public class CharacterSkillActionCard : ActionCard
    {
        public GameOptions.AvailableCharacters Character { get; set; }

        public CharacterSkillActionCard(string id, string backPictureFilePath, string frontPictureFilePath, GameOptions.AvailableExtensions origin, GameOptions.AvailableCharacters character) 
            : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
            Character = character;
        }
    }
}
