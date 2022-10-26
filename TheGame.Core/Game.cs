using System;
using System.Collections.Generic;
using System.Text;

namespace TheGame.Core
{
    public class Game
    {
        public GameSettings GameSettings { get; set; }
        public MainBoard MainBoard { get; set; }

        public Game(GameSettings settings)
        {
            GameSettings = settings;
        }

        public void Initialize()
        {
            //load cards and put them in the right piles
            //initialize characters boards
            //put first card on board (ie initalize mainboard)
            //put characters on first card
            //put curses clue cards in satchel
        }
    }
}
