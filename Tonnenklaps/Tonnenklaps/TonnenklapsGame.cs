using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameDev.Utils;
using Tonnenklaps.Controller;
using Tonnenklaps.Sprites;
using GameDev.Commands;
using GameDev.Scenes;
using Tonnenklaps.Scenes;
using GameDev.Input;
using Tonnenklaps.Commands;
using Tonnenklaps.Util;
using Tonnenklaps.Sound;

namespace Tonnenklaps
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TonnenklapsGame : GameDevGame
    {
        //SpriteBatch spriteBatch;
        ITonnenKlapsController m_Controller;

        public TonnenklapsGame()
        {
            Content.RootDirectory = "Content";
            
            GameDevGame.Current.GraphicsDeviceManager.PreferredBackBufferHeight = 600;
            GameDevGame.Current.GraphicsDeviceManager.PreferredBackBufferWidth = 800;

#if DEBUG
            GameDevGame.Current.GraphicsDeviceManager.IsFullScreen = false;
#else
            GameDevGame.Current.GraphicsDeviceManager.IsFullScreen = true;
#endif
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            GameEnvironment.FastelavnsFont = Content.Load<SpriteFont>("FastelavnsFont");
            // TODO: Add your initialization logic here
            m_Controller = new TonnenKlapsGPController();
            //m_Barrel = new RotatingBarrel(new Vector2(0, 0));
            
            base.Initialize();
        }

        //Scenes
        SceneScheduler m_Scheduler;
        PlayingScene m_PlayingScene;
        ChooseModeScene m_ChooseModeScene;
        SelectPlayerScene m_SelectPlayerScene;
        SplashScene m_SplashScreen;
        WinScene m_WinScene;

        //private RotatingBarrel m_Barrel;

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            m_Scheduler = new SceneScheduler();
            m_Scheduler.MainTune = Music.GetMenuTune();
            m_PlayingScene = new PlayingScene();
            m_ChooseModeScene = new ChooseModeScene(@"Backgrounds\ChooseMode");
            m_SelectPlayerScene = new SelectPlayerScene(@"Backgrounds\JoinPlayers");
            m_SplashScreen = new SplashScene(@"Backgrounds\Splash");
            m_WinScene = new WinScene(@"Backgrounds\Win");

            m_Scheduler.AddSceneChange(
                new SceneChange(m_SplashScreen, m_SelectPlayerScene, gt => m_SplashScreen.TimesUp(gt) || Conditions.ButtonClickedOnAnyController(Buttons.A)));
//            m_Scheduler.AddSceneChange(new SceneChange(m_SelectPlayerScene, m_ChooseModeScene, gt => Conditions.ButtonClickedOnAnyController(Buttons.A)));
            m_Scheduler.AddSceneChange(new SceneChange(m_SelectPlayerScene, m_PlayingScene, gt => Conditions.ButtonClickedOnAnyController(Buttons.A)));
            //m_Scheduler.AddSceneChange(new SceneChange(m_ChooseModeScene, m_SelectPlayerScene, gt => Conditions.ButtonClickedOnAnyController(Buttons.B)));
            //m_Scheduler.AddSceneChange(new SceneChange(m_ChooseModeScene, m_PlayingScene, gt => Conditions.ButtonClickedOnAnyController(Buttons.A)));
//            m_Scheduler.AddSceneChange(new SceneChange(m_PlayingScene, m_ChooseModeScene, gt => Conditions.ButtonClickedOnAnyController(Buttons.B)));
//            m_Scheduler.AddSceneChange(new SceneChange(m_PlayingScene, m_SelectPlayerScene, gt => Conditions.ButtonClickedOnAnyController(Buttons.B)));
            m_Scheduler.AddSceneChange(new SceneChange(m_PlayingScene, m_WinScene, gt => m_PlayingScene.GameOver() ));
//            m_Scheduler.AddSceneChange(new SceneChange(m_PlayingScene, m_WinScene, gt => Conditions.ButtonClickedOnAnyController(Buttons.A)));
            //            m_Scheduler.AddSceneChange(new SceneChange(m_WinScene, m_ChooseModeScene, gt => Conditions.ButtonClickedOnAnyController(Buttons.A)));
            m_Scheduler.AddSceneChange(new SceneChange(m_WinScene, m_SelectPlayerScene, gt => Conditions.ButtonClickedOnAnyController(Buttons.A)));

            Components.Add(m_WinScene);
            Components.Add(m_SplashScreen);
            Components.Add(m_SelectPlayerScene);
            Components.Add(m_ChooseModeScene);
            Components.Add(m_PlayingScene);
            Components.Add(m_Scheduler);

            //Components.Add(m_Barrel);

            base.LoadContent();

            Sounds.PlayMenuKlikDyb();

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            m_Controller.GetState(PlayerIndex.One, gameTime);
            m_Controller.GetState(PlayerIndex.Two, gameTime);
            m_Controller.GetState(PlayerIndex.Three, gameTime);
            m_Controller.GetState(PlayerIndex.Four, gameTime);

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GameDevGame.Current.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
            GameDevGame.Current.SpriteBatch.End();
        }
    }
}
