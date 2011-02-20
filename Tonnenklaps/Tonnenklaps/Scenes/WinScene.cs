using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Scenes;
using Tonnenklaps.Sound;
using Tonnenklaps.Util;
using Microsoft.Xna.Framework;
using Tonnenklaps.Sprites;
using GameDev.Utils;

namespace Tonnenklaps.Scenes
{
    public class WinScene : StaticScene
    {

        private ButtonA m_ButtonA;
        private ButtonY m_ButtonY;


        public WinScene(string textureFile) : base(textureFile)
        {
        }

        private List<Player> m_SortedList;

        public override void OnEnter()
        {
            m_SortedList =  new List<Player>();
            m_SortedList.AddRange(GameEnvironment.CurrentPlayers); 
            m_SortedList.Sort(new PlayerCompare());

            GameEnvironment.CurrentPlayers.ForEach(p =>
            {
                p.Crown.Visible = true;
                p.Crown.Enable();
//                m_SortedList.Add(-p.Points, p); //Trick for at sortere descending
            });

            

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            DrawCrowns(gameTime);
            DrawButtons(gameTime);
        }

        private void DrawButtons(GameTime gameTime)
        {
            if (m_ButtonA.Visible)
            {
                m_ButtonA.Draw(gameTime);
            }
            if (m_ButtonY.Visible)
            {
                m_ButtonY.Draw(gameTime);
            }

        }

        private void DrawCrowns(GameTime gameTime)
        {
            float y = 10;
            foreach (var player in m_SortedList)
            {
                player.Crown.Position = new Vector2(10, y);
                y += 150;
                player.Crown.Draw(gameTime);
                GameDevGame.Current.SpriteBatch.DrawString(GameEnvironment.FastelavnsFontBig, player.Points.ToString(), new Vector2(205, y - 120) + Vector2.One * 4, Color.Black);
                GameDevGame.Current.SpriteBatch.DrawString(GameEnvironment.FastelavnsFontBig, player.Points.ToString(), new Vector2(205, y - 120) , Color.White);

            }

        }

        protected override void LoadContent()
        {
            m_ButtonA = new ButtonA(new Vector2(720, 450), "To Play again");
            AddComponent(m_ButtonA);
            m_ButtonY = new ButtonY(new Vector2(720, 525), "Go To Credits");
            AddComponent(m_ButtonY);

            base.LoadContent();
        }

        



    }
}
