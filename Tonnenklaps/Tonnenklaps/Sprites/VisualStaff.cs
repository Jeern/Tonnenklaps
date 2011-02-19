using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Sprites;
using Microsoft.Xna.Framework;
using GameDev.GraphicUtils;
using Microsoft.Xna.Framework.Graphics;

namespace Tonnenklaps.Sprites
{
    public class VisualStaff : Sprite
    {
        private int m_VisualIndex, m_rotationState;
        private ImageState[] m_imageStates;
        public VisualStaff(Vector2 startpos, int visualIndex, ImageState[] imageStates)
            : base(startpos)
        {
            m_VisualIndex = visualIndex;
            m_imageStates = imageStates;
            this.ImageState = imageStates[0];
        }

        public int RotationState
        {
            get { return m_rotationState; }
            set
            {
                if (value < 0 || value > 2)
                {
                    throw new ArgumentException("RotationStates only between 0 and 2! ... you passed me a value of '" + value + "'.");
                }
                else
                {
                    m_rotationState = value;
                    this.ImageState = m_imageStates[value];
                }
            }
        }

        protected override ImageState ResetImageState()
        {
            return m_imageStates[0];
        }

        public int PhysicalStaffIndex
        {
            get;
            set;
        }
        

      
    }
}
