using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tonnenklaps.Sprites
{
    public class ButtonX : StaticSprite
    {
        public ButtonX(Vector2 vector, string text)
            : base(vector, @"Buttons\ButtonX", text, false)
        {
        }

    }
}
