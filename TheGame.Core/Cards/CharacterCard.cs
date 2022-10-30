namespace TheGame.Core.Cards
{
    public class CharacterCard : Card
    {
        public GameOptions.AvailableCharacters Character { get; set; }

        public CharacterCard(string id, string backPictureFilePath, string frontPictureFilePath, GameOptions.AvailableCharacters character, GameOptions.AvailableExtensions origin)
            : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
            Character = character;
        }
    }
}
