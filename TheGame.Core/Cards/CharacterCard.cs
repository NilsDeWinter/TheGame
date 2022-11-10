namespace TheGame.Core.Cards
{
    public class CharacterCard : Card
    {
        public GameOptions.AvailableCharacters Character { get; set; }

        public CharacterCard(string id, string pictureFilepathBack, string pictureFilepathFront, GameOptions.AvailableExtensions origin, GameOptions.AvailableCharacters character) 
            : base(id, pictureFilepathBack, pictureFilepathFront, origin)
        {
            Character = character;
        }
    }
}
