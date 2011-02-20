using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDev.GraphicUtils;
using GameDev.Utils;
using Tonnenklaps.Util;
using GameDev.Sprites;

namespace Tonnenklaps.Sprites
{
    public class StaticSprite : Sprite
    {
        private string m_Text;

        public StaticSprite(Vector2 vector, string textureFile, string text)
            : base(vector)
        {
            m_Text = text;
            ImageState = new ImageState(new GameImage(Game.Content.Load<Texture2D>(textureFile), 0), StateChangeType.None);
        }



        protected override ImageState ResetImageState()
        {
            return null;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            if (!string.IsNullOrWhiteSpace(m_Text))
            {
                Vector2 textOffSet = new Vector2(77, 20);
                GameDevGame.Current.SpriteBatch.DrawString(GameEnvironment.FastelavnsFont, m_Text, Position + textOffSet + Vector2.One * 2, Color.Black);
                GameDevGame.Current.SpriteBatch.DrawString(GameEnvironment.FastelavnsFont, m_Text, Position + textOffSet, Color.White);
            }
        }
    }
}
