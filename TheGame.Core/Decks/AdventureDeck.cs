using System;
using System.Collections.Generic;
using System.Linq;
using TheGame.Core.Cards;

namespace TheGame.Core.Decks
{

    public class AdventureDeck : List<AdventureCard>
    {
        public AdventureCard PickCard(string number)
        {
            List<AdventureCard> cards = this.Where(c => c.Number == number).ToList();

            if(cards.Count == 0)
            {
                return null;
            }

            List<AdventureCard> cardsWithGreenColor = cards.Where(c => c.Color == Colors.Green).ToList();

            if (cardsWithGreenColor.Count > 0)
            {
                var random = new Random();
                int index = random.Next(cardsWithGreenColor.Count);

                AdventureCard result = cardsWithGreenColor[index];
                this.Remove(result);

                return result;
            }


            List<AdventureCard> cardsWithYellowColor = cards.Where(c => c.Color == Colors.Yellow).ToList();
            if (cardsWithYellowColor.Count > 0)
            {
                var random = new Random();
                int index = random.Next(cardsWithYellowColor.Count);

                AdventureCard result = cardsWithYellowColor[index];
                this.Remove(result);

                return result;
            }

            return null;
        }

        public void ReturnCard(AdventureCard card)
        {
            this.Add(card);
        }
    }
}