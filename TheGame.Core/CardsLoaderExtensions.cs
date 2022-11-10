using System;
using System.Collections.Generic;
using System.Text;
using TheGame.CardsLoader;
using TheGame.Core.Cards;

namespace TheGame.Core
{

    public static class CardsLoaderExtensions
    {
        public static ContainerForCards Map(this List<JsonCard> jsonCards)
        {
            ContainerForCards containerForCards = new ContainerForCards();
            foreach (var jsonCard in jsonCards)
            {
                var card = jsonCard.Map();
                switch (card)
                {
                    case AdvancedSkillActionCard skillCard:
                        containerForCards.AdvancedSkillActionCards.Add(skillCard);
                        break;
                    case CharacterSkillActionCard skillCard:
                        containerForCards.CharacterSkillActionCards.Add(skillCard);
                        break;
                    case CursedActionCard curseCard:
                        containerForCards.CursedActionCards.Add(curseCard);
                        break;
                    case ClueCursedActionCard clueCard:
                        containerForCards.ClueCursedActionCards.Add(clueCard);
                        break;
                    case SkillActionCard skillCard:
                        containerForCards.SkillActionCards.Add(skillCard);
                        break;
                    case AdventureCard adventureCard:
                        containerForCards.AdventureCards.Add(adventureCard);
                        break;
                    case CharacterCard characterCard:
                        containerForCards.CharacterCards.Add(characterCard);
                        break;
                    case ClueCard clueCard:
                        containerForCards.ClueCards.Add(clueCard);
                        break;
                    case ExplorationCard explorationCard:
                        containerForCards.ExplorationCards.Add(explorationCard);
                        break;
                    case SatchelAndNotebookCard satchelAndNotebookCard:
                        containerForCards.SatchelAndNotebookCards.Add(satchelAndNotebookCard);
                        break;
                    case SaveCard saveCard:
                        containerForCards.SaveCards.Add(saveCard);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return containerForCards;
        }

        public static Card Map(this JsonCard jsonCard)
        {
            return jsonCard.Type switch
            {
                "Action curse" => new CursedActionCard(jsonCard.Id, jsonCard.BackPictureName, jsonCard.FrontPictureName
                    , jsonCard.Origin.MapToAvailableExtensions())
                , "Action skill" => new SkillActionCard(jsonCard.Id, jsonCard.BackPictureName, jsonCard.FrontPictureName
                    , jsonCard.Origin.MapToAvailableExtensions())
                , "Action advanced skill" => new AdvancedSkillActionCard(jsonCard.Id, jsonCard.BackPictureName
                    , jsonCard.FrontPictureName, jsonCard.Origin.MapToAvailableExtensions())
                , "Character" => new CharacterCard(jsonCard.Id, jsonCard.BackPictureName, jsonCard.FrontPictureName
                    , jsonCard.Origin.MapToAvailableExtensions(), jsonCard.CharacterName.MapToAvailableCharacter())
                , "Action curse clue" => new ClueCursedActionCard(jsonCard.Id, jsonCard.BackPictureName
                    , jsonCard.FrontPictureName, jsonCard.Origin.MapToAvailableExtensions(), jsonCard.CurseName.MapToAvailableCurses())
                , "Clue" => new ClueCard(jsonCard.Id, jsonCard.BackPictureName, jsonCard.FrontPictureName
                    , jsonCard.Origin.MapToAvailableExtensions(), jsonCard.CurseName.MapToAvailableCurses(), jsonCard.StartingAdventureCard)
                , "Action character skill" => new CharacterSkillActionCard(jsonCard.Id, jsonCard.BackPictureName
                    , jsonCard.FrontPictureName, jsonCard.Origin.MapToAvailableExtensions(), jsonCard.CharacterName.MapToAvailableCharacter())
                , "Exploration" => new ExplorationCard(jsonCard.Id, jsonCard.BackPictureName, jsonCard.FrontPictureName
                    , jsonCard.Origin.MapToAvailableExtensions(), jsonCard.Area)
                , "Adventure" => new AdventureCard(jsonCard.Id, jsonCard.BackPictureName, jsonCard.FrontPictureName
                    , jsonCard.Origin.MapToAvailableExtensions(), jsonCard.Number, jsonCard.Color.MapToAdventureCardColor())
                , "Satchel and notebook" => new SatchelAndNotebookCard(jsonCard.Id, jsonCard.BackPictureName
                    , jsonCard.FrontPictureName, jsonCard.Origin.MapToAvailableExtensions())
                , "Save" => new SaveCard(jsonCard.Id, jsonCard.BackPictureName, jsonCard.FrontPictureName
                    , jsonCard.Origin.MapToAvailableExtensions())
                , _ => new Card(jsonCard.Id, jsonCard.BackPictureName, jsonCard.FrontPictureName, jsonCard.Origin.MapToAvailableExtensions())
            };
        }

        public static Colors MapToAdventureCardColor(this string color)
        {
            return color switch
            {
                "Green" => Colors.Green, "Yellow" => Colors.Yellow, "White" => Colors.White,
                _ => throw new ArgumentException(
                    $"{nameof(CardsLoaderExtensions)}.{nameof(MapToAdventureCardColor)}:No valid color selected")
            };
        }

        public static GameOptions.AvailableCharacters MapToAvailableCharacter(this string character)
        {
            return character switch
            {
                "Ferdinand Lachapellière" => GameOptions.AvailableCharacters.FerdinandLachapelliere,
                "Eliot Pendleton" => GameOptions.AvailableCharacters.EliotPendleton,
                "Dimitri Gorchkov" => GameOptions.AvailableCharacters.DimitriGorchkov,
                "Keelan McCluskey" => GameOptions.AvailableCharacters.KeelanMcCluskey,
                "Howard P. Lovecraft" => GameOptions.AvailableCharacters.HowardPLovecraft,
                "Mary Kingsley" => GameOptions.AvailableCharacters.MaryKingsley,
                "Victor Frankenstein" => GameOptions.AvailableCharacters.VictorFrankenstein,
                "Create your own explorer" => GameOptions.AvailableCharacters.CreateYourOwnExplorer,
                _ => throw new ArgumentException(
                    $"{nameof(CardsLoaderExtensions)}.{nameof(MapToAvailableCurses)}:No valid character selected")
            };
        }

        public static GameOptions.AvailableCurses MapToAvailableCurses(this string curse)
        {
            return curse switch
            {
                "The Voracious Goddess" => GameOptions.AvailableCurses.TheVoraciousGoddess
                ,
                "The Bloody Hunt" => GameOptions.AvailableCurses.TheBloodyHunt
                ,
                "An Offering to the Guardians" => GameOptions.AvailableCurses.AnOfferingToTheGuardians
                ,
                "The Dark Chest of the Damned" => GameOptions.AvailableCurses.TheDarkChestOfTheDamned
                ,
                _ => throw new ArgumentException(
                    $"{nameof(CardsLoaderExtensions)}.{nameof(MapToAvailableCurses)}:No valid curse selected")
            };
        }

        public static GameOptions.AvailableExtensions MapToAvailableExtensions(this string origin)
        {
            return origin switch
            {
                "Base box" => GameOptions.AvailableExtensions.BaseBox
                , _ => throw new ArgumentException($"{nameof(CardsLoaderExtensions)}.{nameof(MapToAvailableExtensions)}:No valid extension selected")
            };
        }
    }
}
