using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Sprites;
using Microsoft.Xna.Framework;

namespace GameDev.Utils
{
    public class Camera
    {
        public Sprite Sprite { get; private set; }

        private Vector2 m_Position;
        public Vector2 Position 
        {
            get 
            {
                if (Sprite == null)
                    return m_Position;

                return m_Position + new Vector2(Sprite.Position.X, 0); 
            }
        }

        public Camera(Vector2 position) : this(null, position)
        {
        }

        public Camera(Sprite sprite, Vector2 position)
        {
            Sprite = sprite;
            m_Position = position;
        }
    }
}
