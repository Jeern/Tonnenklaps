using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Input;
using GameDev.Scenes;
using GameDev.Text;
using GameDev.Utils;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tonnenklaps.Commands;
using Tonnenklaps.Sprites;
using Microsoft.Xna.Framework;
using Tonnenklaps.Util;
using Tonnenklaps.Sound;

namespace Tonnenklaps.Scenes
{

     public enum GameStates {
         GetReady,
        Playing,
        GameOver
        }

    public enum FontSize
    {
     Small,
        Big
    }

    

    public class PlayingScene : Scene
    {
        private DateTime playStateChangedTime;
        public GameStates m_currentPlayState;

        public const int PointsForHit = 3;
        public const int PointsForMiss = -2;

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

        public void SetGameState(GameStates gamestate)
        {
            playStateChangedTime = DateTime.Now;
            m_currentPlayState = gamestate;

            m_Barrel.ShowGlowOnTargetStaff = (gamestate == GameStates.Playing);
        }

        public override void Draw(GameTime gameTime)
        {
            //base.Draw(gameTime);
            DrawBarrel(gameTime);
            DrawCrowns(gameTime);
            DrawClubs(gameTime);
            switch (m_currentPlayState)
            {
                case GameStates.GetReady:
                      DrawWithShadow("Get ready...", new Vector2(210, 180), FontSize.Big);
                DrawWithShadow((3 - (DateTime.Now - playStateChangedTime).Seconds ).ToString(), new Vector2(340, 280), FontSize.Big);
                    break;
                case GameStates.Playing:
                    break;
                case GameStates.GameOver:
                      DrawWithShadow("Round over!", new Vector2(100, 180), FontSize.Big);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
           
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
            m_Barrel.Reset();
            GameEnvironment.CurrentPlayers.ForEach(p =>
                                                       {
                                                           p.Points = 0;
                                                           AddComponent(p.Club);
                                                       });
            SetGameState(GameStates.GetReady);
        }

        public override void OnExit()
        {
            base.OnExit();
            GameEnvironment.CurrentPlayers.ForEach(p => RemoveComponent(p.Club));
            
        }

        private Vector2 PointVectorOffset = new Vector2(45, 35);

        private void DrawCrowns(GameTime gameTime)
        {
            foreach (var currentPlayer in GameEnvironment.CurrentPlayers)
            {
                currentPlayer.Crown.Draw(gameTime);
                DrawWithShadow(currentPlayer.Points.ToString(), currentPlayer.Crown.Position + PointVectorOffset,FontSize.Big);
               

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
            return m_currentPlayState == GameStates.GameOver &&
                   (DateTime.Now - playStateChangedTime) > TimeSpan.FromSeconds(3);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            switch (m_currentPlayState)
            {
                case GameStates.GetReady:
                    if ((DateTime.Now - playStateChangedTime ) > TimeSpan.FromSeconds(3))
                    {
                        SetGameState(GameStates.Playing);
                    }
                    break;

                case GameStates.Playing:

                     foreach (var player in GameEnvironment.CurrentPlayers)
                     {
                         foreach (var buttonValue in (Buttons[]) Enum.GetValues(typeof (Buttons)))
                         {
                             if (GamepadExtended.Current(player.PlayerIndex).IsNewDown(buttonValue))
                             {
                                 player.Club.Slå();
                                 if (m_Barrel.CheckHit(ColorUtils.ButtonToColor(buttonValue)))
                                 {
                                     player.Points += PointsForHit;
                                     player.HitFeedback();
                                     Sound.Sounds.PlayPoint(player.PlayerIndex);
                                     if (m_Barrel.StavesLeft == 0)
                                     {
                                         SetGameState(GameStates.GameOver);
                                     }
                                 }
                                 else
                                 {
                                     player.Points += PointsForMiss;
                                     Sound.Sounds.PlayBarn();
                                 }
                             }
                         }
                     }
                    break;
                case GameStates.GameOver:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void DrawWithShadow(string text, Vector2 position, FontSize size)
        {
            SpriteFont fontToUse = size == FontSize.Small
                                       ? GameEnvironment.FastelavnsFont
                                       : GameEnvironment.FastelavnsFontBig;
            GameDevGame.Current.SpriteBatch.DrawString(fontToUse, text, position + Vector2.One * 4, Color.Black);
            GameDevGame.Current.SpriteBatch.DrawString(fontToUse,text, position, Color.White);
        }

    }
}
