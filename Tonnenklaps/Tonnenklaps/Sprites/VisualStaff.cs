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
        private int m_VisualIndex;
        public VisualStaff(Vector2 startpos, int visualIndex) : base(startpos)
        {
            m_VisualIndex = visualIndex;
            ImageState = ResetImageState();
        }


        protected override ImageState ResetImageState()
        {
            return new ImageState(new GameImage(Game.Content.Load<Texture2D>(string.Format(@"Barrel\barrel00{0}", GetIndexString())), 0), StateChangeType.None);
        }

        public int PhysicalStaffIndex
        {
            get;
            set;
        }

        private string GetIndexString()
        {
            return m_VisualIndex.ToString().PadLeft(2, '0');
        }
    }
}
