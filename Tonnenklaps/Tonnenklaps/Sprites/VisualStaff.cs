using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Sprites;
using Microsoft.Xna.Framework;
using GameDev.GraphicUtils;

namespace Tonnenklaps.Sprites
{
    public class VisualStaff : Sprite
    {
        public VisualStaff(Game game, Vector2 startpos) : base(game, startpos)
        {

        }


        protected override ImageState ResetImageState()
        {
            throw new NotImplementedException();
        }
    }
}
