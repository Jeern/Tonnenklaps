using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tonnenklaps.Controller
{
    public class TonnenKlapsBuzzController : ITonnenKlapsController
    {
        public void GetState(PlayerIndex index, GameTime gametime)
        {
            throw new NotImplementedException();
        }

        public TKButtons CurrentState(PlayerIndex index)
        {
            throw new NotImplementedException();
        }

        public void SendSignal(PlayerIndex index, bool on)
        {
            throw new NotImplementedException();
        }

        public bool IsDown(PlayerIndex index, TKButtons buttons)
        {
            throw new NotImplementedException();
        }
    }
}
