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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            GameEnvironment.CurrentPlayers = new List<Player>();
            var crown = new Crown();
            crown.Position = new Vector2(10, 10);
            m_Crowns.Add(crown);
            SetPlayer(PlayerIndex.One, crown);
            AddComponent(crown);
            crown = new Crown();
            crown.Position = new Vector2(100, 10);
            m_Crowns.Add(crown);
            SetPlayer(PlayerIndex.Two, crown);
            AddComponent(crown);
            crown = new Crown();
            crown.Position = new Vector2(190, 10);
            m_Crowns.Add(crown);
            SetPlayer(PlayerIndex.Three, crown);
            AddComponent(crown);
            crown = new Crown();
            crown.Position = new Vector2(280, 10);
            m_Crowns.Add(crown);
            SetPlayer(PlayerIndex.Four, crown);
            AddComponent(crown);
            base.LoadContent();
        }

        private void SetPlayer(PlayerIndex playerIndex, Crown crown)
        {
            if (GamePad.GetCapabilities(playerIndex).IsConnected)
            {
                var player = new Player(Vector2.Zero);
                player.PlayerIndex = playerIndex;
                player.Crown = crown;
                crown.TheColor = ColorUtils.GetFrontColor(ColorUtils.GetPlayerColor(playerIndex));
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
