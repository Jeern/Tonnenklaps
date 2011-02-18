using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Tonnenklaps.Model;

namespace Tonnenklaps.Sprites
{
    public abstract class Barrel : DrawableGameComponent
    {
        public const int NumberOfStaffs = 12;
        public PhysicalStaff[] m_PhysicalStaffs = new PhysicalStaff[NumberOfStaffs];
        public VisualStaff[] m_VisualStaffs = new VisualStaff[NumberOfStaffs];

        public Barrel(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            Reset();
            base.Initialize();
        }

        public virtual void Reset()
        {
            for (int i = 0; i < NumberOfStaffs; i++)
            {
                m_PhysicalStaffs[i] = new PhysicalStaff();
                m_PhysicalStaffs[i].Destroyed = false;
                m_PhysicalStaffs[i].Color = Color.Red;
                m_VisualStaffs[i] = new VisualStaff(Game, Vector2.Zero);
                m_VisualStaffs[i].PhysicalStaffIndex = i;
            }
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < NumberOfStaffs; i++)
            {
                m_VisualStaffs[i].TheColor = m_PhysicalStaffs[m_VisualStaffs[i].PhysicalStaffIndex].Color;
                m_VisualStaffs[i].Visible = !m_PhysicalStaffs[m_VisualStaffs[i].PhysicalStaffIndex].Destroyed;
            }
        }

        public override void Draw(GameTime gameTime)
        {
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

        
    }
}
