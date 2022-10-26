using System;

namespace TheGame.Core
{
    /// <summary>
    /// All available game possibilities
    /// </summary>
    public static class GameOptions
    {
        public enum AvailableCharacters
        {
            FerdinandLachapelliere,
            EliotPendleton,
            DimitriGorchkov,
            KeelanMcCluskey,
            HowardPLovecraft,
            MaryKingsley,
            VictorFrankenstein
        }
        public static string GetString(this AvailableCharacters availableCharacterEnum)
        {
            return availableCharacterEnum switch
            {
                AvailableCharacters.FerdinandLachapelliere => "Ferdinand Lachapellière",
                AvailableCharacters.EliotPendleton => "Eliot Pendleton",
                AvailableCharacters.DimitriGorchkov => "Dimitri Gorchkov",
                AvailableCharacters.KeelanMcCluskey => "Keelan McCluskey",
                AvailableCharacters.HowardPLovecraft => "Howard P.Lovecraft",
                AvailableCharacters.MaryKingsley => "Mary Kingsley",
                AvailableCharacters.VictorFrankenstein => "Victor Frankenstein",
                _ => throw new ArgumentException("No valid character selected")
            };
        }

        public enum AvailableCurses
        {
            TheVoraciousGoddess,
            TheBloodyHunt,
            AnOfferingToTheGuardians,
            TheDarkChestOfTheDamned
        }

        
        public static string GetString(this AvailableCurses availableCurses)
        {
            return availableCurses switch
            {
                AvailableCurses.TheVoraciousGoddess => "The Voracious Goddess",
                AvailableCurses.TheBloodyHunt => "The Bloody Hunt",
                AvailableCurses.AnOfferingToTheGuardians => "An Offering to the Guardians",
                AvailableCurses.TheDarkChestOfTheDamned => "The Dark Chest of the Damned",
                _ => throw new ArgumentException("No valid curse selected")
            };
        }

        public enum AvailableModes
        {
            Easy,
            Standard,
            Hard
        }
        public static string GetString(this AvailableModes availableModes)
        {
            return availableModes switch
            {
                AvailableModes.Easy => "Easy",
                AvailableModes.Standard => "Standard",
                AvailableModes.Hard => "Hard",
                _ => throw new ArgumentException("No valid mode selected")
            };
        }
    }
}
