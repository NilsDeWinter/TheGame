namespace TheGame.CardsLoader
{
    public class JsonCard
    {
        private const string DEFAULT_PICTURE_FOLDER = @"C:\Users\nils.dewinter\Documents\Privat - Nils\the7thContinent\Jeu de base\";
        private readonly string _pictureFolder;
        private string _backPictureName;
        private string _frontPictureName;
        public string Id { get; set; }
        public string Origin { get; set; }
        public string Type { get; set; }

        public string BackPictureName
        {
            get => _pictureFolder+_backPictureName;
            set => _backPictureName = value;
        }

        public string FrontPictureName
        {
            get => _pictureFolder+_frontPictureName;
            set => _frontPictureName = value;
        }
        
        public string CurseName { get; set; }
        public string CharacterName { get; set; }
        public string Area { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }
        public string StartingAdventureCard { get; set; }

        /// <summary>
        /// Parameterless constructor needed for Json deserialization
        /// </summary>
        public JsonCard()
        {
        }

        public JsonCard(string id, string origin, string type, string backPictureName, string frontPictureName, string pictureFolder = DEFAULT_PICTURE_FOLDER)
        {
            Id = id;
            Origin = origin;
            Type = type;
            BackPictureName = backPictureName;
            FrontPictureName = frontPictureName;
            _pictureFolder = pictureFolder;
        }
    }
}
