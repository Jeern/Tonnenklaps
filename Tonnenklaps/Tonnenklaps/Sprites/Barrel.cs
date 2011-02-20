using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.GraphicUtils;
using GameDev.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tonnenklaps.Model;
using Tonnenklaps.Util;
using GameDev.Utils;

namespace Tonnenklaps.Sprites
{
    public abstract class Barrel : DrawableGameComponent
    {
        public const int NumberOfStaves = 12;
        public const int NumberOfVisualRepresentationsPerStaff = 3;
        public PhysicalStaff[] m_PhysicalStaves = new PhysicalStaff[NumberOfStaves];
        public VisualStaff[] m_VisualStaves = new VisualStaff[NumberOfStaves];
        Texture2D[] Stafftextures = new Texture2D[NumberOfStaves * NumberOfVisualRepresentationsPerStaff];
        private Random rnd = new Random();
        public bool ShowGlowOnTargetStaff { get; set; }
        protected Sprite[] m_glowImages = new Sprite[3];

        public Barrel(Vector2 position)
            : base(GameDevGame.Current)
        {
            m_CurrentPosition = Vector2.Zero;
            m_StartPosition = position;
            Initialize();
            for (int i = 0; i < NumberOfStaves; i++)
            {
                m_PhysicalStaves[i] = new PhysicalStaff();

            }
        }

        public override void Initialize()
        {
            base.Initialize();
            Initialized = true;
        }

        protected bool Initialized = false;

        protected override void LoadContent()
        {
            base.LoadContent();
            Texture2D currentTexture = null;
            for (int staffCounter = 0; staffCounter < NumberOfStaves; staffCounter++)
            {
                ImageState[] imageStates = new ImageState[NumberOfVisualRepresentationsPerStaff];
                for (int imageCounter = 0; imageCounter < NumberOfVisualRepresentationsPerStaff; imageCounter++)
                {
                    //Barrel_00_00
                    string imageName = string.Format("Barrel\\Barrel_{0:00}_{1:00}", staffCounter, imageCounter);
                    currentTexture = GameDevGame.Current.Content.Load<Texture2D>(imageName);

                    Stafftextures[staffCounter * NumberOfVisualRepresentationsPerStaff + imageCounter] = currentTexture;
                    imageStates[imageCounter] = currentTexture;
                }

                m_VisualStaves[staffCounter] = new VisualStaff(this.m_StartPosition, staffCounter, imageStates);


            }



            for (int i = 0; i < NumberOfVisualRepresentationsPerStaff; i++)
            {
                string glowImageName = string.Format(@"Barrel\Glowing\Barrel_00_{0:00}_border", i);
                m_glowImages[i] = new StaffGlow(this.m_StartPosition, GameDevGame.Current.Content.Load<Texture2D>(glowImageName));

            }
        }

        public virtual void Reset()
        {
            for (int i = 0; i < NumberOfStaves; i++)
            {
                m_PhysicalStaves[i].Destroyed = false;// rnd.Next(5) < 2;
                m_PhysicalStaves[i].Color = ColorUtils.GetRandomColor();
                m_VisualStaves[i].RotationState = 0;
                m_VisualStaves[i].PhysicalStaffIndex = i;
            }

            m_VisualStaves[0].Targetable = true;

            SetStartPositions();
        }

        private void SetStartPositions()
        {
            SetPosition(m_StartPosition);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Initialized)
                return;

            for (int i = 0; i < NumberOfStaves; i++)
            {
                Color aColor = ColorUtils.ConvertColor(m_PhysicalStaves[m_VisualStaves[i].PhysicalStaffIndex].Color);

                m_VisualStaves[i].TheColor = aColor;
                m_VisualStaves[i].ColorWhenTargetable = new Color(Math.Min((byte)255, aColor.R + 80),
                    Math.Min((byte)255, aColor.G + 80),
                    Math.Min((byte)255, aColor.B + 80));

                m_VisualStaves[i].Visible = !m_PhysicalStaves[m_VisualStaves[i].PhysicalStaffIndex].Destroyed;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (!Initialized)
                return;
            //Optimeret efter at fra 0-4 er forrest, fra 5-11 er bagest.
            m_VisualStaves[5].Draw(gameTime);
            m_VisualStaves[6].Draw(gameTime);
            m_VisualStaves[4].Draw(gameTime);
            m_VisualStaves[7].Draw(gameTime);
            m_VisualStaves[3].Draw(gameTime);
            m_VisualStaves[8].Draw(gameTime);
            m_VisualStaves[2].Draw(gameTime);
            m_VisualStaves[9].Draw(gameTime);
            m_VisualStaves[1].Draw(gameTime);
            m_VisualStaves[10].Draw(gameTime);
            m_VisualStaves[0].Draw(gameTime);
            m_VisualStaves[11].Draw(gameTime);
        }

        private Vector2 m_CurrentPosition;
        private Vector2 m_StartPosition;


        public void SetPosition(Vector2 position)
        {
            foreach (VisualStaff visualStaff in m_VisualStaves)
            {
                visualStaff.Position = position;
            }

            foreach (var mGlowImage in m_glowImages)
            {
                mGlowImage.Position = position;
            }
            m_CurrentPosition = position;
        }

        public float Scale
        {
            set
            {
                foreach (VisualStaff visualStaff in m_VisualStaves)
                {
                    visualStaff.Scale = value;
                }
            }
        }

        public int StavesLeft
        {
            get
            {
                int number = 0;
                for (int i = 0; i < NumberOfStaves; i++)
                {
                    if (!m_PhysicalStaves[i].Destroyed)
                    {
                        number++;
                    }
                }
                return number;
            }
        }
    }
}
