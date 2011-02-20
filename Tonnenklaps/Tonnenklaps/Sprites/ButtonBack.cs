using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tonnenklaps.Sprites
{
    public class ButtonBack : StaticSprite
    {
        public ButtonBack(Vector2 vector, string text)
            : base(vector, @"Buttons\BackButton", text, true)
        {
        }

    }
}
