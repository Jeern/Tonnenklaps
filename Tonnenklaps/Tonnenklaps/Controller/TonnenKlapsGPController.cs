using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using GameDev.Input;
using Microsoft.Xna.Framework.Input;

namespace Tonnenklaps.Controller
{
    public class TonnenKlapsGPController : ITonnenKlapsController
    {

        public void GetState(PlayerIndex index, GameTime gametime)
        {
            GamepadExtended.Current(index).GetState(gametime);
        }

        public TKButtons CurrentState(PlayerIndex index)
        {
            //switch(
            TKButtons state = TKButtons.None;
            GamePadState gpState = GamepadExtended.Current(index).CurrentState;
            if (gpState.IsButtonDown(Buttons.A))
                state = state | TKButtons.Green;
            if (gpState.IsButtonDown(Buttons.Y))
                state = state | TKButtons.Yellow;
            if (gpState.IsButtonDown(Buttons.B))
                state = state | TKButtons.Red;
            if (gpState.IsButtonDown(Buttons.X))
                state = state | TKButtons.Blue;

            return state;            
        }

        public void SendSignal(PlayerIndex index, bool on)
        {
            //GamepadExtended.Current(index).CurrentState.
            if(on)
            {
                GamePad.SetVibration(index, 1, 1);
            }
            else
            {
                GamePad.SetVibration(index, 0, 0);
            }
        }

        public bool IsDown(PlayerIndex index, TKButtons buttons)
        {
            TKButtons currentState = CurrentState(index);

            return (currentState & buttons) == buttons;
        }


    }
}
