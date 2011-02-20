using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tonnenklaps.Util;
using Microsoft.Xna.Framework;
using Tonnenklaps.Sprites;

namespace Tonnenklaps.Scenes
{
    public class CreditsScene : StaticScene
    {
        private ButtonA m_ButtonA;

        public CreditsScene(string textureFile) : base(textureFile)
        {
        }


        public override void OnEnter()
        {
            foreach (var player in GameEnvironment.CurrentPlayers)
            {
                player.Crown.Enabled = false;
                player.Crown.Visible = false;
            }
        }

        protected override void LoadContent()
        {
            m_ButtonA = new ButtonA(new Vector2(720, 525), "To Play again");
            AddComponent(m_ButtonA);

            base.LoadContent();
        }


        private void DrawButtons(GameTime gameTime)
        {
            if (m_ButtonA.Visible)
            {
                m_ButtonA.Draw(gameTime);
            }
        }


    }
}
