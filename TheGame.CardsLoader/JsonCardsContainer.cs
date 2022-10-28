using System.Collections.Generic;

namespace TheGame.CardsLoader
{
    /// <summary>
    /// Container needed to deserialize the json file
    /// </summary>
    public class JsonCardsContainer
    {
        public List<JsonCard> Cards { get; set; }

        public JsonCardsContainer()
        {

        }

        public JsonCardsContainer(List<JsonCard> cards)
        {
            Cards = cards;
        }
    }
}
