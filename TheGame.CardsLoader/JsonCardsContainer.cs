using System.Collections.Generic;

namespace TheGame.CardsLoader
{
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
