using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev.Utils
{
    public static class GameExtensions
    {
        private static GraphicsDeviceManager m_GraphicsDeviceManager = null;

        public static GraphicsDeviceManager GraphicsDeviceManager(this Game game)
        {
            if (m_GraphicsDeviceManager == null)
            {
                m_GraphicsDeviceManager = new GraphicsDeviceManager(game);
            }
            return m_GraphicsDeviceManager;
        }

        //private static SpriteBatch m_CurrentSpriteBatch = null;

        //public static SpriteBatch CurrentSpriteBatch(this Game game)
        //{
        //    if (m_CurrentSpriteBatch == null)
        //    {
        //        m_CurrentSpriteBatch = new SpriteBatch(game.GraphicsDevice);
        //    }
        //    return m_CurrentSpriteBatch;
        //}

        public static float Height(this Game game)
        {
            return (float)game.GraphicsDevice.Viewport.Height;
        }

        public static float Width(this Game game)
        {
            return (float)game.GraphicsDevice.Viewport.Width;
        }


    }
}
