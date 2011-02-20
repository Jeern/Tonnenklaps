﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Input;
using GameDev.Scenes;
using GameDev.Text;
using GameDev.Utils;
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
        

        public const int PointsForHit = 5;
        public const int PointsForMiss = -1;

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

        private Vector2 PointVectorOffset = new Vector2(45, 35);

        private void DrawCrowns(GameTime gameTime)
        {
            foreach (var currentPlayer in GameEnvironment.CurrentPlayers)
            {
                currentPlayer.Crown.Draw(gameTime);
                GameDevGame.Current.SpriteBatch.DrawString(GameEnvironment.FastelavnsFontBig, currentPlayer.Points.ToString() , currentPlayer.Crown.Position + PointVectorOffset + Vector2.One * 4 , Color.Black);
                GameDevGame.Current.SpriteBatch.DrawString(GameEnvironment.FastelavnsFontBig, currentPlayer.Points.ToString(), currentPlayer.Crown.Position + PointVectorOffset, Color.White);

            }


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
            return false;
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

                        if (m_Barrel.CheckHit(ButtonToColor(buttonValue)))
                        {
                            player.Points += PointsForHit;
                        }
                        else
                        {
                            player.Points += PointsForMiss;
                        }
                    }
                }
            }
        }

        PossibleColors ButtonToColor(Buttons button)
        {
            switch (button)
            {
                case Buttons.A:
                    return PossibleColors.Green;
                    
                case Buttons.B:
                    return PossibleColors.Red;

                case Buttons.X:
                    return PossibleColors.Blue;

                case Buttons.Y:
                    return PossibleColors.Yellow;

                default:
                    throw new ArgumentOutOfRangeException("button");
            }
        }

    }
}
