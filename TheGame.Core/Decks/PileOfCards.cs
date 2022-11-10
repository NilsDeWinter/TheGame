using System;
using System.Collections.Generic;
using System.Linq;

namespace TheGame.Core
{
    public class PileOfCards<Card> : List<Card>
    {
        public PileOfCards() {}

        public PileOfCards(List<Card> cards)
        {
            this.AddRange(cards);
        }

        public (Card pickedCard, bool hadEnoughCards) PickFirstCardOnTop()
        {
            var result = PickCardsOnTop(1);
            return (result.pickedCards[0], result.hadEnoughCards);
        }
        public (List<Card> pickedCards, bool hadEnoughCards) PickCardsOnTop(int numberOfCardsToPick)
        {
            bool hasEnoughCards = true;
            List<Card> pickedCards = new List<Card>();

            if (numberOfCardsToPick > this.Count)
            {
                numberOfCardsToPick = this.Count;
                hasEnoughCards = false;
            }

            for (int i = 0; i < numberOfCardsToPick; i++)
            {
                pickedCards.Add(this.First());
                this.RemoveAt(0);
            }

            return (pickedCards, hasEnoughCards);
        }

        public void Shuffle()
        {
            if (this.Count < 2) return;
            var random = new Random();

            for (int i = 0; i < this.Count; i++)
            {
                int rndIndex = random.Next(i, this.Count);
                var tmpCard = this[rndIndex];
                this[rndIndex] = this[i];
                this[i] = tmpCard;
            }
        }
    }
}