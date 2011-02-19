using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Scenes;
using Tonnenklaps.Sprites;
using Microsoft.Xna.Framework;

namespace Tonnenklaps.Scenes
{
    public class StaticScene : Scene
    {
        private StaticBackground m_Background;
        private string m_TextureFile;

        public StaticScene(string textureFile)
        {
            m_TextureFile = textureFile;
            m_Background = new StaticBackground(m_TextureFile);
            AddComponent(m_Background);
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
