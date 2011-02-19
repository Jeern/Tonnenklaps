using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Input;
using GameDev.Scenes;
using Microsoft.Xna.Framework.Input;
using Tonnenklaps.Commands;
using Tonnenklaps.Sprites;
using Microsoft.Xna.Framework;
using Tonnenklaps.Util;
using Tonnenklaps.Sound;

namespace Tonnenklaps.Scenes
{

     enum PlayStates {
         GetReady,
        Playing,
        Over
        }

    public class PlayingScene : Scene
    {
       

        private RotatingBarrel m_Barrel;

        private List<Vector2> CrownPositions;

        protected override void LoadContent()
        {
            SceneTune = Music.GetGameTune();

            m_Barrel = new RotatingBarrel(new Vector2(30,50));
            AddComponent(m_Barrel);
            m_Barrel.Reset();

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            //base.Draw(gameTime);
            DrawBarrel(gameTime);
            DrawCrowns(gameTime);
            DrawClubs(gameTime);
        }

        private void DrawClubs(GameTime gameTime)
        {
            GameEnvironment.CurrentPlayers.ForEach(player => player.Club.Draw(gameTime, player.TheColor));
        }


        public override void OnEnter()
        {
            base.OnEnter();

            CrownPositions = new List<Vector2>();

            CrownPositions.Add(new Vector2(10));
            CrownPositions.Add(
                new Vector2(GameEnvironment.GameWidth - GameEnvironment.CurrentPlayers[0].Crown.Width - 10, 10));
            CrownPositions.Add(new Vector2(10,
                                           GameEnvironment.GameHeight - GameEnvironment.CurrentPlayers[0].Crown.Height -10));
            CrownPositions.Add(
                new Vector2(GameEnvironment.GameWidth - GameEnvironment.CurrentPlayers[0].Crown.Width - 10,
                            GameEnvironment.GameHeight - GameEnvironment.CurrentPlayers[0].Crown.Height - 10));


            for (int playerCounter = 0; playerCounter < GameEnvironment.CurrentPlayers.Count; playerCounter++)
            {
                GameEnvironment.CurrentPlayers[playerCounter].Crown.Position = CrownPositions[playerCounter];
            }

            GameEnvironment.CurrentPlayers.ForEach(p =>
                                                       {
                                                           p.Crown.Visible = true;
                                                           p.Crown.Enable();
                                                       });

        }

        private void DrawCrowns(GameTime gameTime)
        {
            GameEnvironment.CurrentPlayers.ForEach(player => player.Crown.Draw(gameTime));

        }

        private void DrawBarrel(GameTime gameTime)
        {
            if (m_Barrel.Visible)
            {
                m_Barrel.Draw(gameTime);
            }
        }

        public bool GameOver()
        {
            return true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //foreach player

            //Check whether a new button was 
            foreach (var player in GameEnvironment.CurrentPlayers)
            {
                foreach (var buttonValue in (Buttons[]) Enum.GetValues(typeof(Buttons)))
                {
                    if (GamepadExtended.Current(player.PlayerIndex).IsNewDown(buttonValue))
                    {
                        m_Barrel.m_VisualStaves[0].Visible = false;
                    }
                }
                
            }
            //for each pressed button
            //...check whether
            //  CASE: wrong color => MINUS POINTS
            //  CASE: missing board in barrel => MINUS POINTS
            //  CASE: right color => PLUS POINTS
            

        }


    }
}
