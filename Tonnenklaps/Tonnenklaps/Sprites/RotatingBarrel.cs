using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

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
    }
}
