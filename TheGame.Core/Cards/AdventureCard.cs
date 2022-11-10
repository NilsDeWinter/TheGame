namespace TheGame.Core.Cards
{
    public class AdventureCard : Card
    {
        public string Number { get; set; }
        public int NumberAsInt => int.Parse(Number);

        public Colors Color { get; set; }

        public AdventureCard(string id, string pictureFilepathBack, string pictureFilepathFront, GameOptions.AvailableExtensions origin, string number, Colors color) 
            : base(id, pictureFilepathBack, pictureFilepathFront, origin)
        {
            Number = number;
            Color = color;
        }
    }

    public enum Colors
    {
        Green,
        Yellow,
        White
    }
}