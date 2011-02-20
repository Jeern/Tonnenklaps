using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tonnenklaps.Util;

namespace Tonnenklaps.Scenes
{
    public class CreditsScene : StaticScene
    {
        public CreditsScene(string textureFile) : base(textureFile)
        {
        }


        public override void OnEnter()
        {
            foreach (var player in GameEnvironment.CurrentPlayers)
            {
                player.Crown.Enabled = false;
                player.Crown.Visible = false;
            }
        }


    }
}
