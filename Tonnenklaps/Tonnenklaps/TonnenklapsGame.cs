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
            // TODO: Add your initialization logic here
            m_Controller = new TonnenKlapsGPController();
            m_Barrel = new RotatingBarrel(this, new Vector2(100, 100));
            
            base.Initialize();
        }

        private RotatingBarrel m_Barrel;

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
            Components.Add(m_Barrel);



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
