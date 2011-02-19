using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Scenes;
using GameDev.Utils;
using GameDev.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Tonnenklaps.Util;
using Tonnenklaps.Sprites;

namespace Tonnenklaps.Scenes
{
    public class SelectPlayerScene : StaticScene
    {
        private Crown m_Crown1;
        private Crown m_Crown2;
        private Crown m_Crown3;
        private Crown m_Crown4;

        private List<Crown> m_Crowns = new List<Crown>();


        public SelectPlayerScene(string textureFile) : base(textureFile)
        {
        }

        public override void Initialize()
        {
            GameEnvironment.CurrentPlayers = new List<Player>();
            SetPlayer(PlayerIndex.One);
            SetPlayer(PlayerIndex.Two);
            SetPlayer(PlayerIndex.Three);
            SetPlayer(PlayerIndex.Four);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            var crown = new Crown();
            crown.Position = new Vector2(10, 10);
            m_Crowns.Add(crown);
            AddComponent(crown);
            crown = new Crown();
            crown.Position = new Vector2(100, 10);
            m_Crowns.Add(crown);
            AddComponent(crown);
            crown = new Crown();
            crown.Position = new Vector2(190, 10);
            m_Crowns.Add(crown);
            AddComponent(crown);
            crown = new Crown();
            crown.Position = new Vector2(280, 10);
            m_Crowns.Add(crown);
            AddComponent(crown);
            base.LoadContent();
        }

        private void SetPlayer(PlayerIndex playerIndex)
        {
            if (GamePad.GetCapabilities(playerIndex).IsConnected)
            {
                var player = new Player(Vector2.Zero);
                player.PlayerIndex = playerIndex;
                GameEnvironment.CurrentPlayers.Add(player);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            DrawCrowns(gameTime);
        }

        private void DrawCrowns(GameTime gameTime)
        {
            foreach (Crown crown in m_Crowns)
            {
                crown.Draw(gameTime);
            }
        }


    }
}
