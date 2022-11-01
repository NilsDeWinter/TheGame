namespace TheGame.Core.Cards
{
    public class AdventureCard : Card
    {
        public string Number { get; set; }
        public int NumberAsInt => int.Parse(Number);

        public Colors Color { get; set; }

        public string Area { get; set; } //TODO (4:very low) use enum

        public AdventureCard(string id, string backPictureFilePath, string frontPictureFilePath, Colors color, string number, string area, GameOptions.AvailableExtensions origin)
            : base(id, backPictureFilePath, frontPictureFilePath, origin)
        {
            Color = color;
            Number = number;
            Area = area;
        }
    }

    public enum Colors
    {
        Green,
        Yellow,
        White
    }
}