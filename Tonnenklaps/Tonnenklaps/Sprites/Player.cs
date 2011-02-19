﻿using System;
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

        private int m_Point;

        public int Point
        {
            get 
            { 
                return m_Point; 
            }
            set 
            {
                m_Point = value;
                if (m_Point < 0)
                {
                    m_Point = 0;
                }
            }
        }


    }
}
