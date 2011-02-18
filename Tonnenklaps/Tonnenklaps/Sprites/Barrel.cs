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
        PhysicalStaff[] m_PhysicalStaffs = new PhysicalStaff[NumberOfStaffs];
        VisualStaff[] m_VisualStaffs = new VisualStaff[NumberOfStaffs];

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
            for (int i = 0; i <= NumberOfStaffs; i++)
            {
                m_PhysicalStaffs[i] = new PhysicalStaff();
                m_PhysicalStaffs[i].Destroyed = false;
                m_PhysicalStaffs[i].Color = Color.Red;
                m_VisualStaffs[i] = new VisualStaff(Game, Vector2.Zero);
                m_VisualStaffs[i].PhysicalStaffIndex = i;
            }
        }

        
    }
}
