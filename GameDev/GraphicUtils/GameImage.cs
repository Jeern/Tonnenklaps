using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev.GraphicUtils
{
    public class GameImage
    {
        private Func<int> m_DelayMethod = () => 0;

        public GameImage(Texture2D texture, int delay) : this(texture, () => delay) { }

        public GameImage(Texture2D texture, Func<int> delayMethod)
        {
            Texture = texture;
            m_DelayMethod = delayMethod;
        }

        public Texture2D Texture
        {
            get;
            private set;
        }

        public int DelayValue
        {
            get { return m_DelayMethod(); }
        }

        public void SetDelayFunc( Func<int> delayMethod)
        {
            m_DelayMethod = delayMethod;

        }

        public static implicit operator Texture2D(GameImage image)
        {
            return image.Texture;
        }

        public static implicit operator GameImage(Texture2D texture)
        {
            return new GameImage(texture, 0);
        }



    }
}
