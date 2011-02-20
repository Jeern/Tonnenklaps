using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Tonnenklaps.Model;
using Tonnenklaps.Util;

namespace Tonnenklaps.Sprites
{
    public class RotatingBarrel : Barrel
    {
        private const int RotateMilliseconds = 200; //Number of milliseconds between each barrel rotation.
        private int m_rotationState = 0;
        public RotatingBarrel(Vector2 position)
            : base(position) {}

        private TimeSpan m_LatestRotation = TimeSpan.MaxValue;

        public override void Update(GameTime gameTime)
        {
            if (!Initialized)
                return;

            if (m_LatestRotation == TimeSpan.MaxValue)
            {
                m_LatestRotation = gameTime.TotalGameTime;
            }
            else if (gameTime.TotalGameTime.Subtract(m_LatestRotation).TotalMilliseconds > RotateMilliseconds)
            {
                m_LatestRotation = gameTime.TotalGameTime;
                Rotate();
            }

            base.Update(gameTime);
        }

        private void Rotate()
        {
            m_rotationState = ++m_rotationState % 3;


            for (int i = 0; i < NumberOfStaves; i++)
            {
                m_VisualStaves[i].RotationState = m_rotationState;
                if (m_rotationState == 0)
                {
                    m_VisualStaves[i].PhysicalStaffIndex--;
                }

                if (m_VisualStaves[i].PhysicalStaffIndex < 0)
                {
                    m_VisualStaves[i].PhysicalStaffIndex += NumberOfStaves;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            if (!this.m_PhysicalStaves[m_VisualStaves[0].PhysicalStaffIndex].Destroyed )
            {
                m_glowImages[m_rotationState].Draw(gameTime);   
            }
        }

        public bool CheckHit(PossibleColors color)
        {
            PhysicalStaff staffToHit = m_PhysicalStaves[m_VisualStaves[0].PhysicalStaffIndex];
            if (staffToHit.Destroyed)
            {
                return false;
            }
            else
            {
                if (staffToHit.Color == color)
                {
                    staffToHit.Destroyed = true;
                    return true;    

                }
                return false;
            }
            
        }
    }
}
