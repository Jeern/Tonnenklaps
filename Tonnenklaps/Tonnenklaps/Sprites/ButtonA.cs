using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Sprites;
using Microsoft.Xna.Framework;
using GameDev.GraphicUtils;
using Microsoft.Xna.Framework.Graphics;
using GameDev.Utils;
using Tonnenklaps.Util;

namespace Tonnenklaps.Sprites
{
    public class ButtonA : StaticSprite
    {
        public ButtonA(Vector2 vector, string text) : base(vector, @"Buttons\ButtonA", text, false)
        {
        }

    }
}
