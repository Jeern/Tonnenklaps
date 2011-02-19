using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Scenes;
using Tonnenklaps.Sound;
using Tonnenklaps.Util;
using Microsoft.Xna.Framework;
using Tonnenklaps.Sprites;

namespace Tonnenklaps.Scenes
{
    public class WinScene : StaticScene
    {
        public WinScene(string textureFile) : base(textureFile)
        {
        }


        public override void OnEnter()
        {
            SortedList<int, Player> sortedList = new SortedList<int, Player>();

            GameEnvironment.CurrentPlayers.ForEach(p =>
            {
                p.Crown.Visible = true;
                p.Crown.Enable();
                sortedList.Add(p.Point, p);
            });

            

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            DrawCrowns(gameTime);
        }

        private void DrawCrowns(GameTime gameTime)
        {
            GameEnvironment.CurrentPlayers.ForEach(player => player.Crown.Draw(gameTime));

        }



    }
}
