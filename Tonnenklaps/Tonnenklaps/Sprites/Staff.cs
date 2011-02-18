using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Sprites;
using Microsoft.Xna.Framework;

namespace Tonnenklaps.Sprites
{
    public class Staff : Sprite
    {
        public Staff(Game game, Vector2 startpos) : base(game, startpos)
        {

        }


        protected override GameDev.GraphicUtils.ImageState ResetImageState()
        {
            throw new NotImplementedException();
        }
    }
}
