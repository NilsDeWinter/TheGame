using System;
using System.Collections.Generic;
using System.Linq;
using TheGame.Core.Cards;

namespace TheGame.Core
{
    public class MainBoard
    {
        public List<CardOnMainBoard> listOfCards = new List<CardOnMainBoard>();
        public List<CharacterOnMainBoard> listOfCharacters = new List<CharacterOnMainBoard>();

        public MainBoard(Card firstCard, List<GameOptions.AvailableCharacters> characters)
        {
            listOfCards.Add(new CardOnMainBoard(firstCard, 0, 0));
            listOfCharacters.AddRange(characters.Select(c=> new CharacterOnMainBoard(c,0,0)));
            
        }

        public CardOnMainBoard LayCard(Card card, int positionX, int positionY)
        {
            if (listOfCards.Exists(c => c.Card.Id == card.Id))
            {
                throw new ArgumentException($"The card is already on the board. Card: {card}");
            }

            if (listOfCards.Exists(c => c.PositionX == positionX && c.PositionY == positionY))
            {
                throw new ArgumentException("The position is already occupied.");
            }

            CardOnMainBoard cardOnMainBoard = new CardOnMainBoard(card, positionX, positionY);
            listOfCards.Add(cardOnMainBoard);

            return cardOnMainBoard;
        }

        public void MoveCharacters(List<GameOptions.AvailableCharacters> characters, int newPositionX, int newPositionY)
        {
            var listCharacters = listOfCharacters.Where(c => characters.Contains(c.Character));
            foreach (var character in listCharacters)
            {
                character.PositionX = newPositionX;
                character.PositionY = newPositionY;
            }
        }
    }

    /// <summary>
    /// Represents a card on the main board
    /// </summary>
    public class CardOnMainBoard
    {
        public Card Card { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }


        public CardOnMainBoard(Card card, int positionX, int positionY)
        {
            Card = card;
            PositionX = positionX;
            PositionY = positionY;
        }
    }

    /// <summary>
    /// Represent a character on the main board
    /// </summary>
    public class CharacterOnMainBoard
    {

        public GameOptions.AvailableCharacters Character { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public CharacterOnMainBoard(GameOptions.AvailableCharacters character, int positionX, int positionY)
        {
            Character = character;
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
