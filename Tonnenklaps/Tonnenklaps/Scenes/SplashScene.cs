using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Scenes;
using Microsoft.Xna.Framework;
using GameDev.Utils;
using Tonnenklaps.Sprites;

namespace Tonnenklaps.Scenes
{
    public class SplashScene : StaticScene
    {
        private TimeSpan m_Started = TimeSpan.MaxValue;

        public SplashScene(string textureFile) : base(textureFile)
        {
        }

        public const int Opstartstid = 5000; //Milliseconds

        public bool TimesUp(GameTime gameTime)
        {
            if (m_Started == TimeSpan.MaxValue)
            {
                m_Started = gameTime.TotalGameTime;
            }
            else if (gameTime.TotalGameTime.Subtract(m_Started).TotalMilliseconds > Opstartstid)
            {
                return true;
            }
            return false;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }


    }
}
