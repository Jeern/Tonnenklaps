using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Sprites;
using Microsoft.Xna.Framework;
using GameDev.GraphicUtils;

namespace Tonnenklaps.Sprites
{
    public class Player : Sprite
    {
        public Player(Vector2 startPos) : base(startPos)
        {

        }

        protected override ImageState ResetImageState()
        {
            //Todo: iMPLEMENTER
            throw new NotImplementedException();
        }

        public PlayerIndex PlayerIndex
        {
            get;
            set;
        }

        public Crown Crown
        {
            get;
            set;
        }

        public Club Club { get; set; }


    }
}
