using System;
using System.Collections.Generic;
using System.Text;
using TheGame.CardsLoader;
using TheGame.Core.Cards;

namespace TheGame.Core
{

    public static class CardsLoaderExtensions
    {
        public static ContainerForAllLoadedCards Map(this List<JsonCard> jsonCards)
        {
            ContainerForAllLoadedCards cardsContainer = new ContainerForAllLoadedCards();
            foreach (var jsonCard in jsonCards)
            {
                var card = jsonCard.Map();
                switch (card)
                {
                    case AdvancedSkillActionCard skillCard:
                        cardsContainer.AllAdvancedSkillActionCards.Add(skillCard);
                        break;
                    case CharacterSkillActionCard skillCard:
                        cardsContainer.AllCharacterSkillActionCards.Add(skillCard);
                        break;
                    case CursedActionCard curseCard:
                        cardsContainer.AllCursedActionCards.Add(curseCard);
                        break;
                    case ClueCursedActionCard clueCard:
                        cardsContainer.AllClueCursedActionCards.Add(clueCard);
                        break;
                    case SkillActionCard skillCard:
                        cardsContainer.AllSkillActionCards.Add(skillCard);
                        break;
                    case AdventureCard adventureCard:
                        cardsContainer.AllAdventureCards.Add(adventureCard);
                        break;
                    case CharacterCard characterCard:
                        cardsContainer.AllCharacterCards.Add(characterCard);
                        break;
                    case ClueCard clueCard:
                        cardsContainer.AllClueCards.Add(clueCard);
                        break;
                    case ExplorationCard explorationCard:
                        cardsContainer.AllExplorationCards.Add(explorationCard);
                        break;
                    case SatchelAndNotebookCard satchelAndNotebookCard:
                        cardsContainer.AllSatchelAndNotebookCards.Add(satchelAndNotebookCard);
                        break;
                    case SaveCard saveCard:
                        cardsContainer.AllSaveCards.Add(saveCard);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return cardsContainer;
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
                    , jsonCard.CharacterName.MapToAvailableCharacter(), jsonCard.Origin.MapToAvailableExtensions())
                , "Action curse clue" => new ClueCursedActionCard(jsonCard.Id, jsonCard.BackPictureName
                    , jsonCard.FrontPictureName, jsonCard.CurseName.MapToAvailableCurses(), jsonCard.Origin.MapToAvailableExtensions())
                , "Clue" => new ClueCard(jsonCard.Id, jsonCard.BackPictureName, jsonCard.FrontPictureName
                    , jsonCard.CurseName.MapToAvailableCurses(), jsonCard.StartingAdventureCard, jsonCard.Origin.MapToAvailableExtensions())
                , "Action character skill" => new CharacterSkillActionCard(jsonCard.Id, jsonCard.BackPictureName
                    , jsonCard.FrontPictureName, jsonCard.CharacterName.MapToAvailableCharacter(), jsonCard.Origin.MapToAvailableExtensions())
                , "Exploration" => new ExplorationCard(jsonCard.Id, jsonCard.BackPictureName, jsonCard.FrontPictureName
                    , jsonCard.Area, jsonCard.Origin.MapToAvailableExtensions())
                , "Adventure" => new AdventureCard(jsonCard.Id, jsonCard.BackPictureName, jsonCard.FrontPictureName
                    , jsonCard.Color, jsonCard.Number, jsonCard.Area, jsonCard.Origin.MapToAvailableExtensions())
                , "Satchel and notebook" => new SatchelAndNotebookCard(jsonCard.Id, jsonCard.BackPictureName
                    , jsonCard.FrontPictureName, jsonCard.Origin.MapToAvailableExtensions())
                , "Save" => new SaveCard(jsonCard.Id, jsonCard.BackPictureName, jsonCard.FrontPictureName
                    , jsonCard.Origin.MapToAvailableExtensions())
                , _ => new Card(jsonCard.Id, jsonCard.BackPictureName, jsonCard.FrontPictureName, jsonCard.Origin.MapToAvailableExtensions())
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
                "Howard P.Lovecraft" => GameOptions.AvailableCharacters.HowardPLovecraft,
                "Mary Kingsley" => GameOptions.AvailableCharacters.MaryKingsley,
                "Victor Frankenstein" => GameOptions.AvailableCharacters.VictorFrankenstein,
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
                "Base Game" => GameOptions.AvailableExtensions.BaseGame
                , "The Voracious Goddess" => GameOptions.AvailableExtensions.TheVoraciousGoddess
                , "The Bloody Hunt" => GameOptions.AvailableExtensions.TheBloodyHunt
                , "An Offering to the Guardians" => GameOptions.AvailableExtensions.AnOfferingToTheGuardians
                , "The Dark Chest of the Damned" => GameOptions.AvailableExtensions.TheDarkChestOfTheDamned
                , _ => throw new ArgumentException($"{nameof(CardsLoaderExtensions)}.{nameof(MapToAvailableExtensions)}:No valid extension selected")
            };
        }
    }
}
