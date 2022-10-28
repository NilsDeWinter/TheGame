namespace TheGame.Core.Cards
{
    public class Card
    {
        public string Id { get; set; }
        public string PictureFilepathBack { get; set; }
        public string PictureFilepathFront { get; set; }
        /// <summary>
        /// Is it base game or from an extension
        /// </summary>
        public GameOptions.AvailableExtensions Origin { get; set; }

        public Card(string id, string pictureFilepathBack, string pictureFilepathFront, GameOptions.AvailableExtensions origin)
        {
            Id = id;
            PictureFilepathBack = pictureFilepathBack;
            PictureFilepathFront = pictureFilepathFront;
            Origin = origin;
        }



        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(PictureFilepathBack)}: {PictureFilepathBack}, {nameof(PictureFilepathFront)}: {PictureFilepathFront}, {nameof(Origin)}: {Origin.GetString()}";
        }
    }
}
