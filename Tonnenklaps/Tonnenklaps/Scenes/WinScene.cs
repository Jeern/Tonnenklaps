using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Scenes;
using Tonnenklaps.Sound;

namespace Tonnenklaps.Scenes
{
    public class WinScene : StaticScene
    {
        public WinScene(string textureFile) : base(textureFile)
        {
        }

        protected override void LoadContent()
        {
            SceneTune = Music.GetWinTune();

            base.LoadContent();
        }

    }
}
