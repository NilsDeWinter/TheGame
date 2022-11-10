using System;
using System.Collections.Generic;
using System.Linq;
using TheGame.Core.Cards;

namespace TheGame.Core
{

    public class ExplorationDeck : List<ExplorationCard>
    {
        public ExplorationCard PickCardFromArea(string area)
        {
            List<ExplorationCard> cardsFromArea = this.Where(c => c.Area == area).ToList();

            if(cardsFromArea.Count == 0)
            {
                return null;
            }

            var random = new Random();
            int index = random.Next(cardsFromArea.Count);

            ExplorationCard result = cardsFromArea[index];
            this.RemoveAt(index);

            return result;
        }
    }
}