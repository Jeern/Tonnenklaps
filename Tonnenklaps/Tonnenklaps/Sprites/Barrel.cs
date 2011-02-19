using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Tonnenklaps.Model;
using Tonnenklaps.Util;

namespace Tonnenklaps.Sprites
{
    public abstract class Barrel : DrawableGameComponent
    {
        public const int NumberOfStaffs = 12;
        public PhysicalStaff[] m_PhysicalStaffs = new PhysicalStaff[NumberOfStaffs];
        public VisualStaff[] m_VisualStaffs = new VisualStaff[NumberOfStaffs];

        public Barrel(Game game, Vector2 position) : base(game)
        {
            m_CurrentPosition = Vector2.Zero;
            m_StartPosition = position;
            Initialize();
        }

        public override void Initialize()
        {
            Reset();
            base.Initialize();
            Initialized = true;
        }

        protected bool Initialized = false;

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public virtual void Reset()
        {
            for (int i = 0; i < NumberOfStaffs; i++)
            {
                m_PhysicalStaffs[i] = new PhysicalStaff();
                m_PhysicalStaffs[i].Destroyed = false;
                m_PhysicalStaffs[i].Color = ColorUtils.GetRandomColor();
                m_VisualStaffs[i] = new VisualStaff(Game, Vector2.Zero, i);
                m_VisualStaffs[i].PhysicalStaffIndex = i;
            }
            SetStartPositions();
        }

        private void SetStartPositions()
        {
            //Sætter positionen på hver enkelt VisualStaff.
            //TODO: Gør det her...
            

            
            //Herefter sættes den i forhold til 


            SetPosition(m_StartPosition);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Initialized)
                return;

            for (int i = 0; i < NumberOfStaffs; i++)
            {
                if (i <= 3 || i >= 11)
                {
                    m_VisualStaffs[i].TheColor = ColorUtils.GetFrontColor(m_PhysicalStaffs[m_VisualStaffs[i].PhysicalStaffIndex].Color);
                }
                else
                {
                    m_VisualStaffs[i].TheColor = ColorUtils.GetBackColor(m_PhysicalStaffs[m_VisualStaffs[i].PhysicalStaffIndex].Color);
                }
                m_VisualStaffs[i].Visible = !m_PhysicalStaffs[m_VisualStaffs[i].PhysicalStaffIndex].Destroyed;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (!Initialized)
                return;
            //Optimeret efter at fra 0-4 er forrest, fra 5-11 er bagest.
            m_VisualStaffs[8].Draw(gameTime);
            m_VisualStaffs[7].Draw(gameTime);
            m_VisualStaffs[9].Draw(gameTime);
            m_VisualStaffs[6].Draw(gameTime);
            m_VisualStaffs[10].Draw(gameTime);
            m_VisualStaffs[5].Draw(gameTime);
            m_VisualStaffs[11].Draw(gameTime);
            m_VisualStaffs[0].Draw(gameTime);
            m_VisualStaffs[4].Draw(gameTime);
            m_VisualStaffs[1].Draw(gameTime);
            m_VisualStaffs[3].Draw(gameTime);
            m_VisualStaffs[2].Draw(gameTime);
        }

        private Vector2 m_CurrentPosition;
        private Vector2 m_StartPosition;
        

        public void SetPosition(Vector2 position)
        {
            Vector2 offSet = position - m_CurrentPosition;
            foreach (VisualStaff visualStaff in m_VisualStaffs)
            {
                visualStaff.Position += offSet;
            }
            m_CurrentPosition = position;
        }

        public float Scale
        {
            set
            {
                foreach (VisualStaff visualStaff in m_VisualStaffs)
                {
                    visualStaff.Scale = value;
                }
            }
        }

        
    }
}
