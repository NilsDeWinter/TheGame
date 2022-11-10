namespace TheGame.Core.Cards
{
    public class ExplorationCard : Card
    {
        public string Area { get; set; }

        public ExplorationCard(string id, string pictureFilepathBack, string pictureFilepathFront, GameOptions.AvailableExtensions origin, string area) 
            : base(id, pictureFilepathBack, pictureFilepathFront, origin)
        {
            Area = area;
        }
    }
    
}
