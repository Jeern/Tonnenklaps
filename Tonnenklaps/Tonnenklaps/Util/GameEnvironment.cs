using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tonnenklaps.Sprites;
using Microsoft.Xna.Framework.Graphics;

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

        public static SpriteFont FastelavnsFont
        {
            get; set;
        }


        public static SpriteFont FastelavnsFontBig { get; set; }
    }
}
