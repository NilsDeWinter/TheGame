using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace TheGame.CardsLoader
{
    public class CardsFactory
    {

        //public static string FilePath => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, @"Resources\cards.json");
        public string JsonFilePath { get; set; }

        public CardsFactory(string jsonFilePath)
        {
            JsonFilePath = jsonFilePath;
        }


        public OrganizedCardBox Start()
        {
            if (!File.Exists(JsonFilePath))
            {
                throw new ArgumentException($"Json file not found at {JsonFilePath}");
            }
            
            string json = File.ReadAllText(JsonFilePath);
            var jsonCards = JsonSerializer.Deserialize<JsonCardsContainer>(json);


            OrganizedCardBox organizedCardBox = new OrganizedCardBox();
            foreach (var jsonCard in jsonCards.Cards)
            {;
                switch (jsonCard.Type)
                {
                    case "Save":
                        organizedCardBox.SaveCards.Add(jsonCard);
                        break;
                    case "Satchel and notebook":
                        organizedCardBox.SatchelAndJournalCards.Add(jsonCard);
                        break;
                    case "Action advanced skill":
                        organizedCardBox.ActionAdvancedSkillCards.Add(jsonCard);
                        break;
                    case "Action character skill":
                        organizedCardBox.ActionCharacterSkillCards.Add(jsonCard);
                        break;
                    case "Action curse":
                        organizedCardBox.ActionCurseCards.Add(jsonCard);
                        break;
                    case "Action curse clue":
                        organizedCardBox.ActionCurseClueCards.Add(jsonCard);
                        break;
                    case "Action skill":
                        organizedCardBox.ActionSkillCards.Add(jsonCard);
                        break;
                    case "Adventure":
                        organizedCardBox.AdventureCards.Add(jsonCard);
                        break;
                    case "Character":
                        organizedCardBox.CharacterCards.Add(jsonCard);
                        break;
                    case "Clue":
                        organizedCardBox.ClueCards.Add(jsonCard);
                        break;
                    case "Exploration":
                        organizedCardBox.ExplorationCards.Add(jsonCard);
                        break;
                    default:
                        //TODO write in log file;
                        break;
                }
            }

            return organizedCardBox;
        }
    }

    public class OrganizedCardBox
    {
        public List<JsonCard> SatchelAndJournalCards { get; } = new List<JsonCard>();
        public List<JsonCard> SaveCards = new List<JsonCard>();
        public List<JsonCard> CharacterCards = new List<JsonCard>();
        public List<JsonCard> ClueCards = new List<JsonCard>();
        public List<JsonCard> ActionCurseClueCards = new List<JsonCard>();
        public List<JsonCard> ActionCurseCards = new List<JsonCard>();
        public List<JsonCard> ActionSkillCards = new List<JsonCard>();
        public List<JsonCard> ActionCharacterSkillCards = new List<JsonCard>();
        public List<JsonCard> ActionAdvancedSkillCards = new List<JsonCard>();
        public List<JsonCard> ExplorationCards = new List<JsonCard>();
        public List<JsonCard> AdventureCards = new List<JsonCard>();
    }
}
