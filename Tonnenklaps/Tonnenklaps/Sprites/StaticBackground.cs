using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Sprites;
using GameDev.GraphicUtils;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GameDev.Utils;
using Tonnenklaps.Util;

namespace Tonnenklaps.Sprites
{
    public class StaticBackground : Sprite
    {
        private string m_TextureFile;
        private Vector2 m_StretchScale;

        public StaticBackground(string textureFile) : base(Vector2.Zero)
        {
            m_TextureFile = textureFile;
            ImageState = new ImageState(new GameImage(Game.Content.Load<Texture2D>(m_TextureFile), 0), StateChangeType.None);
            m_StretchScale = new Vector2(GameEnvironment.GameWidth / Width, GameEnvironment.GameHeight / Height);

        }

        protected override ImageState ResetImageState()
        {
            return null;
        }

        public override void Draw(GameTime gameTime)
        {
            GameDevGame.Current.SpriteBatch.Draw(ImageState,
               Position - m_Camera().Position, // + Middle,
               null,
               TheColor,
               0F,
               Vector2.Zero, //Formerly Middle
               m_StretchScale,
               SpriteEffects.None,
               Layer); //Layer
        }
    }
}
