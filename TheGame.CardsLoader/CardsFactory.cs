using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace TheGame.CardsLoader
{
    public class CardsFactory
    {

        public string JsonFilePath { get; set; }

        public CardsFactory(string jsonFilePath)
        {
            JsonFilePath = jsonFilePath;
        }


        public List<JsonCard> Start()
        {
            if (!File.Exists(JsonFilePath))
            {
                throw new ArgumentException($"Json file not found at {JsonFilePath}");
            }
            string json = File.ReadAllText(JsonFilePath);
            var jsonCards = JsonSerializer.Deserialize<JsonCardsContainer>(json);

            return jsonCards.Cards;
        }
    }
}
