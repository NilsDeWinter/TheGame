using System;
using System.Collections.Generic;
using System.Linq;

namespace TheGame.Core
{
    public class PileOfCards<T> : List<T>
    {
        public PileOfCards() {}

        public PileOfCards(List<T> cards)
        {
            this.AddRange(cards);
        }

        public (T pickedCard, bool hadEnoughCards) PickFirstCardOnTop()
        {
            var result = PickCardsOnTop(1);
            return (result.pickedCards[0], result.hadEnoughCards);
        }
        public (List<T> pickedCards, bool hadEnoughCards) PickCardsOnTop(int numberOfCardsToPick)
        {
            bool hasEnoughCards = true;
            List<T> pickedCards = new List<T>();

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