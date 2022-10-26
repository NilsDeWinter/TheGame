using System;
using System.Collections.Generic;

namespace TheGame.Core
{
    public class MainBoard
    {
        public List<CardOnMainBoard> listOfCards = new List<CardOnMainBoard>();

        public MainBoard(Card firstCard)
        {
            listOfCards.Add(new CardOnMainBoard(firstCard, 0, 0));
        }

        public CardOnMainBoard AddCard(Card card, int positionX, int positionY)
        {
            if (listOfCards.Exists(c => c.Card.Id == card.Id))
            {
                throw new ArgumentException($"The card is already on the board. Card: {card.ToString()}");
            }

            if (listOfCards.Exists(c => c.PositionX == positionX && c.PositionY == positionY))
            {
                throw new ArgumentException("The position is already occupied.");
            }

            CardOnMainBoard cardOnMainBoard = new CardOnMainBoard(card, positionX, positionY);
            listOfCards.Add(cardOnMainBoard);

            return cardOnMainBoard;
        }
    }

    /// <summary>
    /// Represents a card on the main board
    /// </summary>
    public class CardOnMainBoard
    {
        private readonly int _positionX;
        private readonly int _positionY;

        public Card Card { get; set; }
        public int PositionX => _positionX;
        public int PositionY => _positionY;


        public CardOnMainBoard(Card card, int positionX, int positionY)
        {
            Card = card;
            _positionX = positionX;
            _positionY = positionY;
        }
        
    }
}
