using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Scenes;
using Microsoft.Xna.Framework;
using GameDev.Utils;
using Tonnenklaps.Sprites;

namespace Tonnenklaps.Scenes
{
    public class SplashScene : StaticScene
    {
        private TimeSpan m_Started = TimeSpan.MaxValue;

        private ButtonA m_ButtonA;

        public SplashScene(string textureFile) : base(textureFile)
        {
        }


        protected override void LoadContent()
        {
            m_ButtonA = new ButtonA(new Vector2(720, 525), "To Play");
            AddComponent(m_ButtonA);
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            DrawButton(gameTime);
        }

        private void DrawButton(GameTime gameTime)
        {
            if (m_ButtonA.Visible)
            {
                m_ButtonA.Draw(gameTime);
            }
        }


    }
}
