using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tonnenklaps.Controller
{
    public interface ITonnenKlapsController
    {
        void GetState(PlayerIndex index, GameTime gametime);
        TKButtons CurrentState(PlayerIndex index);
        void SendSignal(PlayerIndex index, bool on);
        bool IsDown(PlayerIndex index, TKButtons buttons);
    }
}
