using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using GameDev.Utils;

namespace GameDev.Commands
{
    public static class CommandActions
    {
        public static Game Game { get; set; }

        public static void Exit(GameTime time)
        {
            Game.Exit();
        }

        public static void ToggleFullScreen(GameTime time)
        {
            Game.GraphicsDeviceManager().ToggleFullScreen();
        }
    }
}
