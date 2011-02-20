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
        public WinScene(string textureFile) : base(textureFile)
        {
        }

        private List<Player> m_SortedList;

        public override void OnEnter()
        {
            m_SortedList = GameEnvironment.CurrentPlayers;

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
        }

        private void DrawCrowns(GameTime gameTime)
        {
            float y = 10;
            foreach (var player in m_SortedList)
            {
                player.Crown.Position = new Vector2(10, y);
                y += 150;
                player.Crown.Draw(gameTime);
                GameDevGame.Current.SpriteBatch.DrawString(GameEnvironment.FastelavnsFontBig, player.Points.ToString(), new Vector2(220, y-90), Color.Black);

            }

        }



    }
}
