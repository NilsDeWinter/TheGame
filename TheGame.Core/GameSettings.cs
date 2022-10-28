using System.Collections.Generic;

namespace TheGame.Core
{
    public class GameSettings
    {

        public string GameName { get; }
        public List<GameOptions.AvailableCharacters> Characters { get; }
        public List<GameOptions.AvailableCurses> Curses { get; }
        public List<GameOptions.AvailableExtensions> GameExtensions { get; }
        public List<GameOptions.AvailableModes> Modes { get; }

        public GameSettings(string gameName, List<GameOptions.AvailableCharacters> characters, List<GameOptions.AvailableCurses> curses, List<GameOptions.AvailableExtensions> gameExtensions, List<GameOptions.AvailableModes> modes)
        {
            GameName = gameName;
            Characters = characters;
            Curses = curses;
            GameExtensions = gameExtensions;
            Modes = modes;
        }
    }
}
