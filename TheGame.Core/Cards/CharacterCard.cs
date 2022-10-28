namespace TheGame.Core.Cards
{
    public class CharacterCard : Card
    {
        public string CharacterName { get; set; }

        public CharacterCard(string id, string backPictureFilePath, string frontPictureFilePath, string characterName, GameOptions.AvailableExtensions origin)
            : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
            CharacterName = characterName;
        }
    }
}
