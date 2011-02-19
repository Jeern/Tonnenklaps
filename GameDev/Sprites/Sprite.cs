using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDev.GraphicUtils;
using GameDev.Utils;
using System;
using System.Diagnostics;

namespace GameDev.Sprites
{
    public abstract class Sprite : DrawableGameComponent
    {
        protected Func<Camera> m_Camera; // = () => new Camera(null, Vector2.Zero);

        public Sprite(Vector2 startPos, ImageState imgState) : this()
        {
            ImageState = imgState;

        }

        public Sprite() : this(Vector2.Zero)
        {
            
        }
        public Sprite(Vector2 startPos) : this(startPos, () => new Camera(null, Vector2.Zero))
        {
        }

        public Sprite(Vector2 startPos, Func<Camera> camera)
            : base(GameDevGame.Current)
        {
            this.m_Position = startPos;
            m_Camera = camera;
            Layer = 1f;
            this.Scale = 1f;
            TheColor = Color.White;
        }

        public virtual void Reset(Vector2 startPos)
        {
            Scale = 1f;
            if (ImageState == null)
            {
                ImageState = ResetImageState();
            }
            m_Position = startPos;
            TheColor = Color.White;
        }

        public ImageState ImageState
        {
            get; set;   
        }

        protected abstract ImageState ResetImageState();

        public Color TheColor 
        { get; set; }

        public override void Update(GameTime gameTime)
        {
            ImageState.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Draw(gameTime, TheColor);
        }

        public virtual void Draw(GameTime gameTime, Color color)
        {
            base.Draw(gameTime);
            if (Visible)
            {
                GameDevGame.Current.SpriteBatch.Draw(ImageState,
                   Position - (m_Camera().Position * Layer), // + Middle,
                   null,
                   color,
                   0F,
                   Vector2.Zero, //Formerly Middle
                   Scale,
                   SpriteEffects.None,
                   Math.Min(Layer, 1f)); //Layer
            }
        }

        public void BaseDraw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        protected Vector2 m_Position;
        public virtual Vector2 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }

        public float TouchDistance
        {
            get
            {
                return (new Vector2(Width / 3, Height / 3).Length()) * Scale;
            }
        }
        
        protected float m_Scale;
        public float Scale
        {
            get { return m_Scale; }
            set { m_Scale = value; }
        }


        public Vector2 Middle
        {
            get { return new Vector2((float)Width / 2F, (float)Height / 2F) * Scale; }
        }

        public float Layer
        {
            get; set;

        }

        public float Height
        {
            get { return ImageState.CurrentTexture.Height * Scale; }
        }

        public float Width
        {
            get { return ImageState.CurrentTexture.Width * Scale; }
        }
    }
}
