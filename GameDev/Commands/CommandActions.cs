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
        public static void Exit(GameTime time)
        {
            GameDevGame.Current.Exit();
        }

        public static void ToggleFullScreen(GameTime time)
        {
            GameDevGame.Current.GraphicsDeviceManager.ToggleFullScreen();
        }
    }
}
