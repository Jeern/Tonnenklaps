using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Scenes;
using Tonnenklaps.Sprites;
using Microsoft.Xna.Framework;
using Tonnenklaps.Util;

namespace Tonnenklaps.Scenes
{
    public class PlayingScene : Scene
    {
        private RotatingBarrel m_Barrel;
        private Crown m_crown;
        private List<Vector2> CrownPositions;

        protected override void LoadContent()
        {

            m_crown = new Crown();
            AddComponent(m_crown);
            m_Barrel = new RotatingBarrel(Vector2.Zero);
            AddComponent(m_Barrel);
            m_Barrel.Reset();

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            //base.Draw(gameTime);
            DrawBarrel(gameTime);
            DrawCrowns();
        }

        private void DrawCrowns()
        {
           
            
        }

        public override void OnEnter()
        {
            base.OnEnter();

            CrownPositions =  new List<Vector2>();

            CrownPositions.Add(new Vector2( 10));
            CrownPositions.Add(new Vector2(GameEnvironment.GameWidth - GameEnvironment.CurrentPlayers[0].Crown.Width - 10));
            CrownPositions.Add( new Vector2(10, GameEnvironment.GameHeight-GameEnvironment.CurrentPlayers[0].Crown.Height - 10));
            CrownPositions.Add(new Vector2(19));
        }

        private void DrawCrown(GameTime gameTime)
        {
            if (m_crown.Visible)
            {
                m_crown.Draw(gameTime);
            }

           
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
