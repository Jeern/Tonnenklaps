using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.GraphicUtils;
using GameDev.Sprites;
using GameDev.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tonnenklaps.Sprites
{
    public class Crown : Sprite
    {
        private ImageState m_rotatingImageState;

        private int m_imagesInQuarterTurn = 6;

        public Crown()
        {
           Initialize();
            Scale = 0.3F;
        }
     
        protected override void LoadContent()
        {
            GameImage[] images = new GameImage[m_imagesInQuarterTurn];
            for (int i = 0; i < m_imagesInQuarterTurn; i++)
            {
                images[i] = GameDevGame.Current.Content.Load<Texture2D>(string.Format(@"Crown\crown{0:0000}", i));
            }

            m_rotatingImageState = new ImageState(images, StateChangeType.Repeating);
            this.ImageState = m_rotatingImageState;
            this.ImageState.SetDefaultDelay(150);
            base.LoadContent();

        }

        protected override ImageState ResetImageState()
        {
            return m_rotatingImageState;
        }


    }
}
