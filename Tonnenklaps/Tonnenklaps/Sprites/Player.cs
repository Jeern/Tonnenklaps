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
        public Player(Vector2 startPos)
            : base(startPos)
        {

        }

        protected override ImageState ResetImageState()
        {
            return null;
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

        private int m_Point;



        public override void Reset(Vector2 startPos)
        {
            base.Reset(startPos);
            Points = 0;
        }

        public int Points
        {
            get
            {
                return m_Point;
            }
            set { m_Point = Math.Max(0, value); }
        }
    }
}
