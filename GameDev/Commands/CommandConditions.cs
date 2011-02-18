using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using GameDev.Input;
using GameDev.Utils;
using System.Diagnostics;

namespace GameDev.Commands
{
    public static class CommandConditions
    {
        public static Game Game { get; set; }

        public static bool Exit(GameTime time)
        {
            return KeyboardExtended.Current.WasSingleClick(Keys.Escape);
        }

        public static bool ToggleFullScreen(GameTime time)
        {
            return KeyboardExtended.Current.WasSingleClick(Keys.F4) || KeyboardExtended.Current.WasSingleClick(Keys.F11); ;
        }

    }
}
