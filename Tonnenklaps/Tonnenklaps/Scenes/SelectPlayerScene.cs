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
        private DateTime m_nextCheckForConnections = DateTime.MinValue;

        private List<Crown> m_Crowns =  new List<Crown>();
        
        private ButtonA m_ButtonA;
        private List<SimpleText> m_texts = new List<SimpleText>();

        public SelectPlayerScene(string textureFile) : base(textureFile)
        {
            LoadContent();
        }

        public override void OnEnter()
        {
            Initialize();
            base.OnEnter();
            LoadContent();
        }

        private const int Spacing = 200;

        protected override void LoadContent()
        {
            m_ButtonA = new ButtonA(new Vector2(720, 525), "To Play");
            AddComponent(m_ButtonA);
            CheckAndSetup();
            m_nextCheckForConnections = DateTime.Now.AddSeconds(2);
        }

        void CheckAndSetup()
        {
            m_Crowns.ForEach(acrown => { GameDevGame.Current.Components.Remove(acrown);
            Components.Remove(acrown);
            });
            m_Crowns.Clear();
            m_texts.ForEach(text => {GameDevGame.Current.Components.Remove(text);
            Components.Remove(text);});
            m_texts.Clear();
            if (GameEnvironment.CurrentPlayers != null)
            {
                GameEnvironment.CurrentPlayers.ForEach(player => GameDevGame.Current.Components.Remove(player));
                GameEnvironment.CurrentPlayers.Clear();
            }
            

            int textX = 110;
            int crownX = 15;
            
            int crownY = 20;
            int textY = crownY + 65;

          GameEnvironment.CurrentPlayers = new List<Player>();
            Crown crown = new Crown();
            m_Crowns.Add(crown);
            SetPlayer(PlayerIndex.One, crown);
            crown = new Crown();
            m_Crowns.Add(crown);
            SetPlayer(PlayerIndex.Two, crown);
            crown = new Crown();
            m_Crowns.Add(crown);
            SetPlayer(PlayerIndex.Three, crown);
            crown = new Crown();
            m_Crowns.Add(crown);
            SetPlayer(PlayerIndex.Four, crown);


            m_texts.Add(new SimpleText(GetText("P1", PlayerIndex.One), new Vector2(textX, textY), GameEnvironment.FastelavnsFont, Color.White, true));
            textX += Spacing;
            m_texts.Add(new SimpleText(GetText("P2", PlayerIndex.Two), new Vector2(textX, textY), GameEnvironment.FastelavnsFont, Color.White, true));
            textX += Spacing;
            m_texts.Add(new SimpleText(GetText("P3", PlayerIndex.Three), new Vector2(textX, textY), GameEnvironment.FastelavnsFont, Color.White, true));
            textX += Spacing;
            m_texts.Add(new SimpleText(GetText("P4", PlayerIndex.Four), new Vector2(textX, textY), GameEnvironment.FastelavnsFont, Color.White, true));

            
            foreach (Crown acrown in m_Crowns)
            {
                acrown.Position = new Vector2(crownX, crownY);
                crownX += Spacing;
                crown.Visible = false;
            }

            int clubYPos = 10;
            GameEnvironment.CurrentPlayers.ForEach(p => p.Club = new Club(new Vector2(250, clubYPos += 100), Color.SandyBrown));// p.TheColor));

        }

        private string GetText(string def, PlayerIndex playerIndex)
        {
            if (GamePad.GetCapabilities(playerIndex).IsConnected)
                return def;

            return "connect player";
        }

      
        private void SetPlayer(PlayerIndex playerIndex, Crown crown)
        {
            if (GamePad.GetCapabilities(playerIndex).IsConnected)
            {
                var player = new Player(Vector2.Zero);
                player.PlayerIndex = playerIndex;
                player.TheColor = ColorUtils.ConvertColor(ColorUtils.GetPlayerColor(playerIndex));
                player.Crown = crown;
                crown.TheColor = player.TheColor;
                GameEnvironment.CurrentPlayers.Add(player);
                GameDevGame.Current.Components.Add(player);
            }
            else
            {
                crown.TheColor = new Color(50, 50, 50, 10);
                crown.StopRotation();
            }
        }



        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            DrawCrowns(gameTime);
            DrawText(gameTime);
            DrawButton(gameTime);
            
        }

        private void DrawCrowns(GameTime gameTime)
        {
            bool visible = false;
            foreach (Crown crown in m_Crowns)
            {
                visible = crown.Visible;
                crown.Visible = true;
                crown.Draw(gameTime);
                crown.Visible = visible;
            }
        }

        private void DrawText(GameTime gameTime)
        {
            m_texts.ForEach(t => t.Draw(gameTime));
        }
        private void DrawButton(GameTime gameTime)
        {
            if (m_ButtonA.Visible)
            {
                m_ButtonA.Draw(gameTime);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (m_nextCheckForConnections < DateTime.Now)
            {
                m_nextCheckForConnections = DateTime.Now.AddSeconds(2);
                CheckAndSetup();
            }
            m_Crowns.ForEach(c => c.Update(gameTime));
        }


    }
}
