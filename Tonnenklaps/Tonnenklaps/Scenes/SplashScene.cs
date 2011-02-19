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
    public class SplashScene : Scene
    {
        private StaticBackground m_Background;

        public SplashScene()
        {
        }

        protected override void LoadContent()
        {
            m_Background = new StaticBackground(@"Backgrounds\Splash");
            AddComponent(m_Background);
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            DrawBackground(gameTime);
        }

        private void DrawBackground(GameTime gameTime)
        {
            if (m_Background.Visible)
            {
                m_Background.Draw(gameTime);
            }
        }

    }
}
