using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tonnenklaps.Sprites
{
    public class RotatingBarrel : Barrel
    {
        private const int RotateMilliseconds = 500; //Number of milliseconds between each barrel rotation.

        public RotatingBarrel(Game game, Vector2 position) : base(game, position)
        {

        }

        private TimeSpan m_LatestRotation = TimeSpan.MaxValue;

        public override void Update(GameTime gameTime)
        {
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
            for (int i = 0; i < NumberOfStaffs; i++)
            {
                m_VisualStaffs[i].PhysicalStaffIndex--;
                if (m_VisualStaffs[i].PhysicalStaffIndex < 0)
                {
                    m_VisualStaffs[i].PhysicalStaffIndex += NumberOfStaffs;
                }
            }
        }


    }
}
