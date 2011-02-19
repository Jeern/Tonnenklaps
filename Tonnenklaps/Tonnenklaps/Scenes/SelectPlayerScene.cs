using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Scenes;
using GameDev.Utils;
using GameDev.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Tonnenklaps.Util;
using Tonnenklaps.Sprites;

namespace Tonnenklaps.Scenes
{
    public class SelectPlayerScene : StaticScene
    {
        public SelectPlayerScene(string textureFile) : base(textureFile)
        {
            
        }

        public override void Initialize()
        {
            GameEnvironment.CurrentPlayers = new List<Player>();
            SetPlayer(PlayerIndex.One);
            SetPlayer(PlayerIndex.Two);
            SetPlayer(PlayerIndex.Three);
            SetPlayer(PlayerIndex.Four);
            base.Initialize();
        }

        private void SetPlayer(PlayerIndex playerIndex)
        {
            if (GamePad.GetCapabilities(playerIndex).IsConnected)
            {
                var player = new Player(Vector2.Zero);
                player.PlayerIndex = playerIndex;
                GameEnvironment.CurrentPlayers.Add(player);
            }
        }

    }
}
