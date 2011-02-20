using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev.Text
{
    public class SimpleText : DrawableGameComponent 
    {
        public string Text { get; set; }
        public Vector2 Position { get; set; }
        public SpriteFont Font { get; set; }
        public Color Color { get; set; }
        public bool Shadow { get; set; }

        private Vector2 m_size, m_halfSize;
        public Vector2  Size
        {
            get { return m_size; }
            private set { m_size = value; }
        }
        private Vector2 HalfSize
        {
            get { return m_halfSize; }
            set { m_halfSize = value; }
        }


        public SimpleText(string text, Vector2 position, SpriteFont font, Color color, bool shadow) : base(GameDevGame.Current)
        {
            Text = text;
            Position = position;
            Font = font;
            Color = color;
            Shadow = shadow;
            CalculateSize();
        }


        protected void CalculateSize()
        {
            this.Size = Font.MeasureString(Text);
            this.HalfSize = Size/2;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            if (Shadow)
            {
                GameDevGame.Current.SpriteBatch.DrawString(Font, Text, Position - HalfSize + Vector2.One, Microsoft.Xna.Framework.Color.Black);
            }
            GameDevGame.Current.SpriteBatch.DrawString(Font, Text, Position - HalfSize, Color);
            }

    }
}
