using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Scenes;
using Tonnenklaps.Sprites;
using Microsoft.Xna.Framework;

namespace Tonnenklaps.Scenes
{
    public class PlayingScene : Scene
    {
        private RotatingBarrel m_Barrel;
        private Crown m_crown;

        protected override void LoadContent()
        {
            m_Barrel = new RotatingBarrel(Vector2.Zero);
            AddComponent(m_Barrel);
            m_Barrel.Reset();

            m_crown = new Crown();
            AddComponent(m_crown);
     


            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            DrawBarrel(gameTime);
        }

        private void DrawBarrel(GameTime gameTime)
        {
            if (m_Barrel.Visible)
            {
                m_Barrel.Draw(gameTime);
            }
        }


    }
}
