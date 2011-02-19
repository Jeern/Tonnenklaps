using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tonnenklaps.Sprites;

namespace Tonnenklaps.Util
{
    public static class GameEnvironment
    {
        public const int GameWidth = 800;
        public const int GameHeight = 600;

        public static List<Player> CurrentPlayers
        {
            get;
            set; 
        }



    }
}
