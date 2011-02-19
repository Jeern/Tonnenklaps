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
using GameDev.Text;

namespace Tonnenklaps.Scenes
{
    public class SelectPlayerScene : StaticScene
    {

        private List<Crown> m_Crowns = new List<Crown>();
        private TextUtil m_TextUtil1;
        private TextUtil m_TextUtil2;
        private TextUtil m_TextUtil3;
        private TextUtil m_TextUtil4;


        public SelectPlayerScene(string textureFile) : base(textureFile)
        {
        }

        private const int Spacing = 190;

        protected override void LoadContent()
        {
            int textX = 90;
            int crownX = 15;

            m_TextUtil1 = new TextUtil(Vector2.Zero, GameEnvironment.FastelavnsFont, Color.Black, new Vector2(textX, 130), HorizontalAlignment.Left, VerticalAlignment.Top);
            m_TextUtil1.SetText(GetText("P1", PlayerIndex.One));
            AddComponent(m_TextUtil1);
            textX += Spacing;
            m_TextUtil2 = new TextUtil(Vector2.Zero, GameEnvironment.FastelavnsFont, Color.Black, new Vector2(textX, 130), HorizontalAlignment.Left, VerticalAlignment.Top);
            m_TextUtil2.SetText(GetText("P2", PlayerIndex.Two));
            AddComponent(m_TextUtil2);
            textX += Spacing;
            m_TextUtil3 = new TextUtil(Vector2.Zero, GameEnvironment.FastelavnsFont, Color.Black, new Vector2(textX, 130), HorizontalAlignment.Left, VerticalAlignment.Top);
            m_TextUtil3.SetText(GetText("P3", PlayerIndex.Three));
            AddComponent(m_TextUtil3);
            textX += Spacing;
            m_TextUtil4 = new TextUtil(Vector2.Zero, GameEnvironment.FastelavnsFont, Color.Black, new Vector2(textX, 130), HorizontalAlignment.Left, VerticalAlignment.Top);
            m_TextUtil4.SetText(GetText("P4", PlayerIndex.Four));
            AddComponent(m_TextUtil4);

            GameEnvironment.CurrentPlayers = new List<Player>();
            var crown = new Crown();
            //crown.Position = new Vector2(crownX, 20);
            m_Crowns.Add(crown);
            SetPlayer(PlayerIndex.One, crown);
            AddComponent(crown);
            crownX += Spacing;
            crown = new Crown();
            //crown.Position = new Vector2(crownX, 20);
            m_Crowns.Add(crown);
            SetPlayer(PlayerIndex.Two, crown);
            AddComponent(crown);
            crownX += Spacing;
            crown = new Crown();
            //crown.Position = new Vector2(crownX, 10);
            m_Crowns.Add(crown);
            SetPlayer(PlayerIndex.Three, crown);
            AddComponent(crown);
            crownX += Spacing;
            crown = new Crown();
            //crown.Position = new Vector2(crownX, 10);
            m_Crowns.Add(crown);
            SetPlayer(PlayerIndex.Four, crown);
            AddComponent(crown);
            base.LoadContent();

            int clubYPos = 0;
            GameEnvironment.CurrentPlayers.ForEach(p => p.Club = new Club(new Vector2(300, clubYPos += 50), p.TheColor));

        }

        private string GetText(string def, PlayerIndex playerIndex)
        {
            if (GamePad.GetCapabilities(playerIndex).IsConnected)
                return def;

            return "??";
        }

        public override void OnEnter()
        {
            int crownX = 10;
            foreach (Crown crown in m_Crowns)
            {
                crown.Position = new Vector2(crownX, 10);
                crownX += Spacing;
            }
        }

        private void SetPlayer(PlayerIndex playerIndex, Crown crown)
        {
            if (GamePad.GetCapabilities(playerIndex).IsConnected)
            {
                var player = new Player(Vector2.Zero);
                player.PlayerIndex = playerIndex;
                player.TheColor = ColorUtils.GetRandomColor(ColorUtils.GetPlayerColor(playerIndex));
                player.Crown = crown;
                crown.TheColor = player.TheColor;
                GameEnvironment.CurrentPlayers.Add(player);
            }
            else
            {
                crown.TheColor = new Color(255, 255, 255, 200);
            }
        }



        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            DrawCrowns(gameTime);
            DrawText(gameTime);
        }

        private void DrawCrowns(GameTime gameTime)
        {
            foreach (Crown crown in m_Crowns)
            {
                crown.Draw(gameTime);
            }
        }

        private void DrawText(GameTime gameTime)
        {
            m_TextUtil1.Draw(gameTime);
            m_TextUtil2.Draw(gameTime);
            m_TextUtil3.Draw(gameTime);
            m_TextUtil4.Draw(gameTime);
        }

    }
}
