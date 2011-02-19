using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using GameDev.Input;
using Microsoft.Xna.Framework;

namespace Tonnenklaps.Commands
{
    public static class Conditions
    {
        public static bool ButtonClickedOnAnyController(Buttons button)
        {
            return
                GamepadExtended.Current(PlayerIndex.One).WasSingleClick(button) |
                GamepadExtended.Current(PlayerIndex.Two).WasSingleClick(button) |
                GamepadExtended.Current(PlayerIndex.Three).WasSingleClick(button) |
                GamepadExtended.Current(PlayerIndex.Four).WasSingleClick(button);
        }
    }
}
